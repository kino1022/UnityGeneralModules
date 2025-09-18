using GeneralModule.Status.Value.Interface;

namespace GeneralModule.Status.Interface {
    /// <summary>
    /// ステータスの値を管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public interface IStatus<Type> {
        
        IValueModule<Type> RawValue { get; }
        
        Type Value { get; }

        void Set(Type value);

        void Increase(Type amount);
        
        void Decrease(Type amount);
        
    }
}