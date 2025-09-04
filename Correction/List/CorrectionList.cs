using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.List.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralModule.Correction.List {
    [Serializable]
    public class CorrectionList : ICorrectionList {

        [Title("データ")]
        [OdinSerialize, LabelText("管理している補正値の分類")]
        protected ICorrectionType m_type;

        [OdinSerialize, LabelText("管理している補正値")]
        protected List<ICorrectionInstance> m_corrections;

        public IReadOnlyList<ICorrectionInstance> Corrections => m_corrections;

        public ICorrectionType Type => m_type;

        public CorrectionList(ICorrectionType type) {
            if (type is null) {
                throw new ArgumentNullException("type");
            }
        }

        public void Dispose () {

        }

        public void Add (ICorrectionInstance instance) {

            if (instance is null || instance.Type is null) {
                throw new ArgumentNullException();
            }

            if (Type.GetType() == instance.Type.GetType()) {
                return;
            }

            RemoveNullInstance();

            m_corrections.Add (instance);
        }

        public void Remove (ICorrectionInstance instance) {

            if (instance is null || instance.Type is null) {
                throw new ArgumentNullException();
            }

            if (Type.GetType() == instance.Type.GetType()) {
                return;
            }

            RemoveNullInstance();

            m_corrections.Remove (instance);
        }

        public void Clear () {
            m_corrections.Clear();
        }

        public float Apply(float value) {
            RemoveNullInstance();
            return Type.Apply(value, m_corrections);
        }

        protected void RemoveNullInstance () {
            m_corrections.RemoveAll(x => x is null);
        }
    }
}