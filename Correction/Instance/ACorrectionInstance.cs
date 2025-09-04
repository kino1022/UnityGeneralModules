using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using System;

namespace GeneralModule.Correction.Instance {
    [Serializable]
    public abstract class ACorrectionInstance : ICorrectionInstance {

        protected ICorrectionType m_type;

        protected float m_value;

        public ICorrectionType@Type => m_type;

        public float Value => m_value;

        protected ACorrectionInstance(float value, ICorrectionType type) {

        }

        public virtual void Dispose () {

        }
    }
}