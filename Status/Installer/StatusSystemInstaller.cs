using System;
using GeneralModule.Status.Value;
using GeneralModule.Status.Value.Interface;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Status.Installer {
    /// <summary>
    /// ゲーム中でこの名前空間のオブジェクトを利用する際に必要になるオブジェクトのInstaller
    /// </summary>
    [Serializable]
    public class StatusSystemInstaller : IInstaller {

        [OdinSerialize]
        private IValueModule<int> m_intValueModule = new IntValueModule();
        
        [OdinSerialize]
        private IValueModule<float> m_floatValueModule = new FloatValueModule();

        public void Install(IContainerBuilder builder) {

            builder.Register(m_intValueModule,Lifetime.Singleton).As<IValueModule<int>>();
            
            builder.RegisterInstance(m_floatValueModule).As<IValueModule<float>>();
            
        }
    }
}