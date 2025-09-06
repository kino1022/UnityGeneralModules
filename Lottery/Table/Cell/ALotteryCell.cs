using System;
using GeneralModule.Lottery.Table.Cell.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Lottery.Table.Cell {
    public abstract class ALotteryCell<Type> : ILotteryCell<Type> {

        [OdinSerialize, LabelText("抽選アイテム")]
        protected Type m_item;

        [SerializeField, LabelText("確率"), ProgressBar(0.0f, 100.0f)]
        protected float m_rate;

        public Type Item => m_item;

        public float Rate => m_rate;

        public void SetRate(float value) {
            
            if (value < 0.0f || value > 100.0f) {
                throw new ArgumentOutOfRangeException();
            }

            m_rate = value;
        }
    }
}