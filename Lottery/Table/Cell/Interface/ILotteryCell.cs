namespace GeneralModule.Lottery.Table.Cell.Interface {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public interface ILotteryCell<Type> {
        float Rate { get; }

        Type Item { get; }

        void SetRate(float value);
    }
}