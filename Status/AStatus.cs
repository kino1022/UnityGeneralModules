using System;
using GeneralModule.Status.Interface;
using GeneralModule.Status.Value.Interface;
using Sirenix.OdinInspector;
using VContainer;

namespace UnityGeneralModules.Status {
    public class AStatus<Type> : SerializedMonoBehaviour , IStatus<Type> {

        protected IValueModule<Type> m_rawValue;
        
        protected IObjectResolver m_resolver;
        
        public IValueModule<Type> RawValue => m_rawValue;

        public Type Value => Get();
        
        [Inject]
        public void Construct(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public void Start() {
            m_rawValue = m_resolver.Resolve<IValueModule<Type>>();
        }

        protected virtual Type Get() {
            return m_rawValue.Value;
        }

        public virtual void Set(Type value) {
            m_rawValue.Set(value);
        }

        public virtual void Increase(Type value) {
            m_rawValue.Increase(value);
        }

        public virtual void Decrease(Type value) {
            m_rawValue.Decrease(value);
        }
    }
}