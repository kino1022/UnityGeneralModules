using System;
using GeneralModule.Calculator.Interface;
using GeneralModule.Status.Value;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Calculator.Installer {
    [Serializable]
    public class CalculatorInstaller : IInstaller {
        
        [OdinSerialize]
        private ICalculator<int> m_intCalculator;
        
        [OdinSerialize]
        private ICalculator<float> m_floatCalculator;

        public void Install(IContainerBuilder builder) {
            
            builder
                .RegisterInstance(m_intCalculator)
                .As<ICalculator<int>>();
            
            builder
                .RegisterInstance(m_floatCalculator)
                .As<ICalculator<float>>();
        }
    }
}