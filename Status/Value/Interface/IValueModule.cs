namespace GeneralModule.Status.Value.Interface {
    /// <summary>
    /// 値を管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public interface IValueModule<Type> {
        
        Type Value { get; }
        
        void Set (Type value);
        
    }
}