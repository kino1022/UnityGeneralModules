using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralModule.Correction.Definition.Type {
    [Serializable]
    public class FixedTypeProperty : ACorrectionTypeProperty {

        public override float Apply(float value, List<ICorrectionInstance> corrections) {

            if (corrections == null||corrections.Count is 0) {
                return value;
            }

            var totalValue = 0.0f;

            corrections.ForEach(x => totalValue += x.Value);

            return value + totalValue;
        }
    }
}