namespace GeneralModule.Status.Core.Interface {
    public interface IValueManager<T> {
        
        T Value { get; }
        
        bool AllowMinus { get; }

        void Set(T value);

        void ChangeAllowMinus(bool value);

        void Increase(T amount);
        
        void Decrease(T amount);
        
    }
}