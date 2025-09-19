using System;

namespace GeneralModule.Amount.Module.Interface {
    public interface IObserveZeroModule : IDisposable {
        
        Action OnZero { get; set; }
        
    }
}