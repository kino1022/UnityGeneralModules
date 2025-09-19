using System;
using GeneralModule.Amount.Interface;
using GeneralModule.Amount.Module.Interface;
using R3;

namespace GeneralModule.Amount.Module {
    
    public class ObserveZeroModule : IObserveZeroModule {
        
        protected CompositeDisposable m_disposable = new CompositeDisposable();
        
        public Action OnZero { get; set; }

        public ObserveZeroModule(IAmountModule amount) {
            RegisterObserve(amount);
        }

        public void Dispose() {
            m_disposable?.Dispose();
        }

        protected void RegisterObserve(IAmountModule module) {

            if (module is null) {
                throw new ArgumentNullException(nameof(module));
            }
            
            m_disposable = new CompositeDisposable();
            
            module.Amount
                .Subscribe(x => {
                    if (x == 0) {
                        OnZero?.Invoke();
                    }
                })
                .AddTo(m_disposable);
        }
    }
}