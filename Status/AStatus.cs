using System;
using GeneralModule.Calculator.Interface;
using GeneralModule.Status.Interface;
using GeneralModule.Status.Value.Interface;
using Sirenix.OdinInspector;
using VContainer;

namespace GeneralModule.Status {
    public abstract class AStatus<Type> : SerializedMonoBehaviour , IStatus<Type> {

        protected IValueModule<Type> m_rawValue;
        
        protected ICalculator<Type> m_calculator;
        
        protected IObjectResolver m_resolver;
        
        public IValueModule<Type> RawValue => m_rawValue;

        public Type Value => Get();
        
        [Inject]
        public virtual void Construct(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public virtual void Start() {
            
            m_rawValue = m_resolver.Resolve<IValueModule<Type>>();
            
            m_calculator = m_resolver.Resolve<ICalculator<Type>>();
            
        }

        protected virtual Type Get() {
            return m_rawValue.Value;
        }

        public virtual void Set(Type value) {
            m_rawValue.Set(value);
        }

        public virtual void Increase(Type value) {
            var newValue = m_calculator.Add(Get(), value);
            Set(newValue);
        }

        public virtual void Decrease(Type value) {
            var newValue = m_calculator.Subtract(Get(), value);
            Set(newValue);
        }
    }
}