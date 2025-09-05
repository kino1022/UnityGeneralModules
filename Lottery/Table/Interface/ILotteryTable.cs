using System.Collections.Generic;
using GeneralModule.Lottery.Table.Cell.Interface;

namespace GeneralModule.Lottery.Table.Interface {
    public interface ILotteryTable<Type> {
        
        List<ILotteryCell<Type>> Table { get; }

        void SetCell(ILotteryCell<Type> cell);
    }
}