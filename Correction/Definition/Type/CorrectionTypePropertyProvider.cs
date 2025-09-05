using GeneralModule.Correction.Definition.Type.Interface;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace GeneralModule.Correction.Definition.Type {
    [Serializable]
    public class CorrectionTypePropertyProvider : SerializedScriptableObject, ICorrectionTypePropertyProvider {

        [OdinSerialize]
        protected Dictionary<CorrectionType, ICorrectionTypeProperty> m_properties = new();

        public ICorrectionTypeProperty Provide (CorrectionType type) {

            var result = m_properties[type];

            if (result is null) {
                throw new NullReferenceException();
            }

            return result;
        }
    }
}