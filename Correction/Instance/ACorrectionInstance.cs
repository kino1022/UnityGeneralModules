using GeneralModule.Correction.Definition.Type;
using GeneralModule.Correction.Instance.Interface;
using System;

namespace GeneralModule.Correction.Instance {
    [Serializable]
    public abstract class ACorrectionInstance : ICorrectionInstance {

        protected CorrectionType m_type;

        protected float m_value;

        public CorrectionType　Type => m_type;

        public float Value => m_value;

        protected ACorrectionInstance(float value, CorrectionType type) {
            m_value = value;
            m_type = type;
        }

        public virtual void Dispose () {
            
        }
    }
}