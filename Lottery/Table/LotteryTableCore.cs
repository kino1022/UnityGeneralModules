using GeneralModule.Lottery.Table.Cell.Interface;
using GeneralModule.Lottery.Table.Interface;
using NUnit.Framework;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralModule.Lottery.Table {
    [Serializable]
    public class LotteryTableCore<Type> : ILotteryTable<Type> {

        [OdinSerialize, LabelText("抽選テーブル")]
        protected List<ILotteryCell<Type>> m_table = new();

        public List<ILotteryCell<Type>> Table => m_table;

        public Type Lottery () {
            float random = UnityEngine.Random.Range(0.0f, 100.0f);

            float probability = 0.0f;

            foreach (var cell in Table) {
                probability += cell.Rate;
                if (random < probability) {
                    return cell.Item;
                }
            }

            return Table[Table.Count - 1].Item;
        }

        protected void NormalizeRate() {
            var totalRatio = CalculateTotalRate();

            if (totalRatio is 0.0f) {
                return;
            }

            m_table.ForEach(x => x.SetRate((x.Rate / totalRatio) * 100.0f));
        }

        protected float CalculateTotalRate() {
            return m_table.Sum(x => x.Rate);
        }
    }
}