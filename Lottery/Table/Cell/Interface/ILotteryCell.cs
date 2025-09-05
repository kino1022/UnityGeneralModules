namespace GeneralModule.Lottery.Table.Cell.Interface {
    public interface ILotteryCell<Type> {
        float Rate { get; }

        Type Item { get; }

        void SetRatio(float value);
    }
}