using GeneralModule.Correction.Manager.Interface;
using GeneralModule.Status.Interface;
using GeneralModule.Status.Value.Interface;
using System.Collections;
using UnityEngine;
using UnityGeneralModules.Status;

namespace Assets.UnityGeneralModules.Status {
    public abstract class ACorrectableStatus<Type> : AStatus<Type> , ICorrectableStatus<Type> {

        protected IValueModule<Type> m_correctedValue;

        protected ICorrectionManager m_corrector;

        public IValueModule<Type> CorrectedValue => m_correctedValue;

        public ICorrectionManager Correction => m_corrector;


        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        protected void ApplyCorrection () {

            dynamic value = m_rawValue.Value;

            dynamic corrected = m_corrector.Apply(value);

            m_correctedValue.Set(corrected);
        }
    }
}