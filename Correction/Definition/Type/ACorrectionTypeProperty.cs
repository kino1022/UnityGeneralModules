using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralModule.Correction.Definition.Type {
    [Serializable]
    public abstract class ACorrectionTypeProperty : ICorrectionTypeProperty {

        [TitleGroup("Ý’è")]
        [SerializeField]
        protected int m_priority = 1;

        public int Priority => m_priority;

        public abstract float Apply(float value, List<ICorrectionInstance> corrections);
    }
}