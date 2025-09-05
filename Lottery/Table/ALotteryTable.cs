using System;
using System.Collections.Generic;
using System.Linq;
using GeneralModule.Lottery.Table.Cell.Interface;
using GeneralModule.Lottery.Table.Interface;

namespace GeneralModule.Lottery.Table {
    public abstract class ALotteryTable<Type> : ILotteryTable<Type> {

        protected List<ILotteryCell<Type>> m_cells = new();
        
        public List<ILotteryCell<Type>> Table => m_cells;

        public void SetCell(ILotteryCell<Type> cell) {

            if (cell is null) {
                throw new ArgumentNullException();
            }
            
            m_cells.Add(cell);
            NormalizeRate();
        }
        
        protected void NormalizeRate() {
            var totalRatio = CalculateTotalRate();
            
            if (totalRatio is 0.0f) {
                return;
            }

            m_cells.ForEach(x => x.SetRatio((x.Rate /　totalRatio) * 100.0f));
        }

        protected float CalculateTotalRate() {
            return m_cells.Sum(x => x.Rate);
        }
    }
}