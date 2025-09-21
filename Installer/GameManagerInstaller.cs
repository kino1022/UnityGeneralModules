using System.Collections.Generic;
using GeneralModule.Calculator.Installer;
using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Installer;
using GeneralModule.Counter;
using GeneralModule.Counter.Interface;
using GeneralModule.Status.Installer;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Installer {

    /// <summary>
    /// 親スコープがレジスターするべき汎用クラスをインストールするインストーラー
    /// </summary>
    public class GameManagerInstaller : SerializedScriptableObject, IInstaller {
        

        [OdinSerialize] private List<IInstaller> m_installers = new List<IInstaller>() {
            new CorrectionSystemInstaller(),
            new StatusSystemInstaller(),
            new CalculatorInstaller()
        };
        
        public void Install(IContainerBuilder builder) {
    
        }
    }
}