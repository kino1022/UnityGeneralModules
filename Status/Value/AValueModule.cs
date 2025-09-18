using System;
using GeneralModule.Calculator.Interface;
using GeneralModule.Status.Value.Interface;

namespace GeneralModule.Status.Value {
    [Serializable]
    public abstract class AValueModule<Type> : IValueModule<Type> {

        protected Type m_value;
        
        protected ICalculator<Type> m_calculator;
        
        public Type Value => m_value;

        protected AValueModule(ICalculator<Type> calculator) {
            m_calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public virtual void Set(Type value) {
            m_value = value;
        }

        public virtual void Increase(Type amount) {
            m_value = m_calculator.Add(m_value, amount);
        }

        public virtual void Decrease(Type amount) {
            m_value = m_calculator.Subtract(m_value, amount);
        }
    }
}