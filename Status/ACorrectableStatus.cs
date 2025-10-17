using GeneralModule.Correction.Manager.Interface;
using GeneralModule.Status.Interface;
using GeneralModule.Status.Value.Interface;
using System.Collections;
using UnityEngine;
using GeneralModule.Status;
using VContainer;

namespace GeneralModule.Status {
    public abstract class ACorrectableStatus<Type> : AStatus<Type> , ICorrectableStatus<Type> {

        protected IValueModule<Type> m_correctedValue;

        protected ICorrectionManager m_corrector;

        public IValueModule<Type> CorrectedValue => m_correctedValue;

        public ICorrectionManager Corrector => m_corrector;

        protected override void Start() {
            
            base.Start();
            
            m_correctedValue = m_resolver.Resolve<IValueModule<Type>>();
            
            m_corrector = m_resolver.Resolve<ICorrectionManager>();
        }
        
        protected void ApplyCorrection () {

            dynamic value = m_rawValue.Value;

            dynamic corrected = m_corrector.Apply(value);

            m_correctedValue.Set(corrected);
        }
    }
}