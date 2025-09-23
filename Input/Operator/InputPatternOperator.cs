using System;
using System.Collections.Generic;
using System.Linq;
using GeneralModule.Input.Signal;
using R3;
using UnityEngine.InputSystem;

namespace GeneralModule.Input.Operator {
    public static class InputPatternOperator {
        public static Observable<T> OnPressed<T>(this Observable<T> source) where T : InputSignal
        {
            return source.Where(x => x.Phase == InputActionPhase.Started);
        }
        
        public static Observable<InputSignal> Hold(this Observable<InputSignal> source, TimeSpan duration)
        {
            return source.Where(x => x.Phase == InputActionPhase.Started)
                .Select(startSignal => 
                        Observable.Timer(duration)
                            .TakeUntil(source.Where(x => x.Phase == InputActionPhase.Canceled))
                            .Select(_ => startSignal) // 押下開始時の情報を流す
                )
                .Switch();
        }
        
        public static Observable<InputSignal[]> Tap(this Observable<InputSignal> source, int count, long interval) {
            return source
                .OnPressed()
                .Timestamp()
                .Scan(
                    new List<(long timestamp, InputSignal value)>(),
                    (list, current) => {
                        list.Add(current);
                        if (list.Count > count) {
                            list.RemoveAt(0);
                        }

                        return list;
                    })
                .Where(list => list.Count == count)
                .Where(list => (list[^1].timestamp - list[0].timestamp) <= interval)
                .Select(list => list.Select(item => item.value).ToArray());
    }
        
        public static Observable<TimeSpan> Charge(this Observable<InputSignal> source, TimeSpan chargeTime) {
            return source
                .OnPressed()
                .Select(start => (StartTime: start.Time,
                    CancelledStream: source.Where(x => x.Phase == InputActionPhase.Canceled)))
                .SelectMany(t => t.CancelledStream.Select(end => TimeSpan.FromSeconds(end.Time - t.StartTime)))
                .Where(duration => duration < chargeTime);
        }
        
        public static Observable<Unit> Chord(this Observable<InputSignal> source, params Observable<InputSignal>[] others)
        {
            // // 各ストリームを「押されているか(bool)」のストリームに変換
            // var allStreams = others.Concat( new[] with {source})
            //     .Select(s => s.Select(x => x.Phase == InputActionPhase.Started || x.Phase == InputActionPhase.Performed)
            //         .DistinctUntilChanged());

            var allStream = others
                .Concat(new List<Observable<InputSignal>>(others.ToList()))
                .Select(s => s
                    .FirstAsync()
                    .ToObservable()
                    .Select(x => x.Phase == InputActionPhase.Started || x.Phase == InputActionPhase.Canceled))
                .Distinct();

            // すべてのストリームの最新値を合成し、すべてtrueになった瞬間を検知
            return Observable
                .CombineLatest(allStream)
                .Where(s => s.All(IsPressed => IsPressed))
                .Select(_ => Unit.Default)
                .ThrottleFirst(TimeSpan.FromMilliseconds(1));
        }
    }
}