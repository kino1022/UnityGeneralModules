using System;
using GeneralModule.Correction.Applier.Interface;
using GeneralModule.Correction.Definition.Type;
using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Manager;
using GeneralModule.Correction.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Correction.Installer {
    /// <summary>
    /// 補正値システムを利用する上で必要になるクラスをDIコンテナに注入するためのIInstaller
    /// </summary>
    [Serializable]
    public class CorrectionSystemInstaller : IInstaller {

        [OdinSerialize] 
        protected ICorrectionTypePropertyProvider m_provider = SerializedScriptableObject.CreateInstance<CorrectionTypePropertyProvider>();
        

        public void Install (IContainerBuilder builder) {
            
            if (m_provider is null) {
                return;
            }

            builder
                .RegisterInstance(m_provider)
                .As<ICorrectionTypePropertyProvider>();
            
        }
    }
}