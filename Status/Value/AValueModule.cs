using System;
using GeneralModule.Calculator.Interface;
using GeneralModule.Status.Value.Interface;
using VContainer;

namespace GeneralModule.Status.Value {
    [Serializable]
    public abstract class AValueModule<Type> : IValueModule<Type> {

        protected Type m_value;
        
        [Inject]
        protected ICalculator<Type> m_calculator;
        
        public Type Value => m_value;

        public virtual void Set(Type value) {
            m_value = value;
        }
    }
}