using System;
using System.Collections.Generic;
using GeneralModule.Calculator.Installer;
using GeneralModule.Correction.Installer;
using GeneralModule.Status.Installer;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Installer {

    /// <summary>
    /// 親スコープがレジスターするべき汎用クラスをインストールするインストーラー
    /// </summary>
    [Serializable]
    public class GameManagerInstaller : IInstaller {
        

        [OdinSerialize] private List<IInstaller> m_installers = new List<IInstaller>() {
            new CorrectionSystemInstaller(),
            new StatusSystemInstaller(),
            new CalculatorInstaller()
        };
        
        public void Install(IContainerBuilder builder) {

            foreach (var installer in m_installers) {
                installer.Install(builder);
            }
        }
    }
}