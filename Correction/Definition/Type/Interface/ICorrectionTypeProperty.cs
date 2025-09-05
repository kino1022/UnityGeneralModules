using GeneralModule.Correction.Instance.Interface;
using System.Collections.Generic;

namespace GeneralModule.Correction.Definition.Type.Interface {
    public interface ICorrectionTypeProperty {
        int Priority { get; }

        float Apply(float value, List<ICorrectionInstance> corrections);
    }
}