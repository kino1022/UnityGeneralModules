using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Counter;
using GeneralModule.Counter.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Installer {

    /// <summary>
    /// 親スコープがレジスターするべき汎用クラスを
    /// </summary>
    public class GameManagerInstaller : SerializedScriptableObject, IInstaller {
        
        [OdinSerialize, LabelText("プロパティ供給クラス")]
        protected ICorrectionTypePropertyProvider m_correctionTypePropertyProvider;

        [OdinSerialize, LabelText("タイムカウンター")] 
        protected ITimeCounter m_timeCounter;
        

        public void Install(IContainerBuilder builder) {

        }
    }
}