using System;

namespace GeneralModule.Counter.Interface {
    public interface ITimeCounter : IDisposable
    {

        float Count { get; }

        bool IsProgress { get; }

        void Start();

        void Stop();

        void Reset();
    }
}