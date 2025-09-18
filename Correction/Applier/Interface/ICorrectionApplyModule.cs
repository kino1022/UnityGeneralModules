using GeneralModule.Correction.Instance.Interface;
using System.Collections.Generic;

namespace GeneralModule.Correction.Applier.Interface {
    public interface ICorrectionApplyModule {

        float Apply(float value, List<ICorrectionInstance> corrections);
        
        
    }
}