using GeneralModule.Correction.Instance.Interface;
using System;
using System.Collections.Generic;

namespace GeneralModule.Correction.Definition.Type {
    [Serializable]
    public class RatioTypeProperty : ACorrectionTypeProperty {
        public override float Apply(float value, List<ICorrectionInstance> corrections) {

            if (corrections is null || corrections.Count is 0) {
                return value;
            }

            var totalValue = 0.0f;

            corrections.ForEach(x => totalValue += x.Value);

            return totalValue * (totalValue * 0.01f);
        }
    }
}