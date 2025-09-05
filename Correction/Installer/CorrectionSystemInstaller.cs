using GeneralModule.Correction.Definition.Type.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Correction.Installer {
    /// <summary>
    /// 補正値システムを利用する上で必要になるクラスをDIコンテナに注入するためのIInstaller
    /// </summary>
    public class CorrectionSystemInstaller : SerializedScriptableObject , IInstaller {

        [OdinSerialize]
        protected ICorrectionTypePropertyProvider m_provider;

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