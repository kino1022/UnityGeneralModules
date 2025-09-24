using System;
using VContainer.Unity;
using R3;
using GeneralModule.Input.Signal;
using UnityEngine;
using UnityEngine.Events;
using GeneralModule.Input.Provider.Interface;

namespace GeneralModule.Input.Asset.Cell.Interface {
    public interface IInputContextCell : IStartable , IDisposable {

        /// <summary>
        /// 入力が成立した際のコールバック
        /// </summary>
        UnityEvent<InputSignal> OnInput { get; }
        
        /// <summary>
        /// 入力が成立した際に発火されるObservable
        /// </summary>
        Observable<InputSignal> Signal { get; }

        /// <summary>
        /// 入力を他のストリームへ伝達するためのObservable
        /// </summary>
        Observable<Unit> Stream { get; }

        /// <summary>
        /// ストリームを生成して入力を監視する
        /// </summary>
        /// <param name="provider"></param>
        void RegisterInput(IInputObservableProvider provider);

    }
}