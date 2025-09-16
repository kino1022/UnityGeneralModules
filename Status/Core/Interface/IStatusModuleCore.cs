namespace GeneralModule.Status.Core.Interface {
    public interface IStatusModuleCore<T> {
        
        IValueManager<T> Value { get; }
        
        IValueManager<T> RawValue { get; }

        void Set(T value);
    }
}