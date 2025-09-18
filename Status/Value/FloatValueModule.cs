using System;
using GeneralModule.Calculator.Interface;
using VContainer;

namespace GeneralModule.Status.Value {
    [Serializable]
    public class FloatValueModule : AValueModule<float> {
        
        [Inject]
        public FloatValueModule(ICalculator<float> calculator) : base(calculator) { }
        
    }
}