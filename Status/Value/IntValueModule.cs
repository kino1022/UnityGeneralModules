using System;
using GeneralModule.Calculator.Interface;
using VContainer;

namespace GeneralModule.Status.Value {
    
    [Serializable]
    public class IntValueModule : AValueModule<int> {
        
        [Inject]
        public IntValueModule (ICalculator<int> calculator) : base(calculator) { }
        
    }
}