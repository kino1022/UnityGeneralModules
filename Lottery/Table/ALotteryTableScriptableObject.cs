using System;
using System.Collections.Generic;
using System.Linq;
using GeneralModule.Lottery.Table.Cell.Interface;
using GeneralModule.Lottery.Table.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Lottery.Table {
    public abstract class ALotteryTableScriptableObject<Type> : SerializedScriptableObject, ILotteryTable<Type> {

        [OdinSerialize, LabelText("抽選テーブル")]
        protected List<ILotteryCell<Type>> m_cells = new();
        
        public List<ILotteryCell<Type>> Table => m_cells;
        
        #if UNITY_EDITOR
        
        private int currentLength = 0;

        [SerializeField]
        [LabelText("確率の自動正規化")]
        protected bool m_autoNormalize = true;

        private void OnValidate() {
            if (m_cells.Count != currentLength && m_autoNormalize) {
                NormalizeRate();
            }
        }
        
        #endif

        public Type Lottery() {
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

        public void SetCell(ILotteryCell<Type> cell) {

            if (cell is null) {
                throw new ArgumentNullException();
            }
            
            m_cells.Add(cell);
            NormalizeRate();
        }
        
        [Button("確率の正規化")]
        protected void NormalizeRate() {
            var totalRatio = CalculateTotalRate();
            
            if (totalRatio is 0.0f) {
                return;
            }

            m_cells.ForEach(x => x.SetRate((x.Rate /　totalRatio) * 100.0f));
        }

        protected float CalculateTotalRate() {
            return m_cells.Sum(x => x.Rate);
        }
    }
}