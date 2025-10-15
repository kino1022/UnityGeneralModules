using System;
using GeneralModule.Amount.Interface;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Amount {
    [Serializable]
    public class AmountModule : IAmountModule {

        [OdinSerialize]
        protected ReactiveProperty<int> m_amount;
        
        [ShowInInspector]
        private int CurrentAmount => m_amount.Value;
        
        public ReadOnlyReactiveProperty<int> Amount => m_amount;

        public AmountModule(int amount) {
            
            if (!IsValueIntegrate(amount)) {
                throw new ArgumentOutOfRangeException();
            }
            
            m_amount = new ReactiveProperty<int>(amount);
        }

        [Button("値のセット"),ProgressBar(0,100)]
        public void Set(int value) {
            
            if (!IsValueIntegrate(value)) {
                throw new System.ArgumentOutOfRangeException();
            }
            
            m_amount.Value = value;
        }
        
        [Button("値の増加"),ProgressBar(0,100)]
        public void Increase(int amount) {

            if (amount <= 0) {
                throw new System.ArgumentOutOfRangeException();
            }
            
            m_amount.Value += amount;
        }
        
        [Button("値の減少"), ProgressBar(0,100)]
        public void Decrease(int amount) {

            if (amount > 0) {
                throw new System.ArgumentOutOfRangeException();
            }
            
            m_amount.Value -= amount;
        }

        protected bool IsValueIntegrate(int value) {
            if (value <= 0) return false;
            
            return true;
        }
    }
}