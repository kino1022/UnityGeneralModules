using R3;

namespace GeneralModule.Amount.Interface {
    public interface IAmountModule {
        
        ReadOnlyReactiveProperty<int> Amount { get; }

        void Set(int value);

        void Increase(int amount);
        
        void Decrease(int amount);
        
    }
}