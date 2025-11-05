using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Scope {
    /// <summary>
    /// POCOクラスのインストーラーをインストールするためのクラス
    /// </summary>
    public class InstallerList : SerializedMonoBehaviour, IInstaller {
        
        [OdinSerialize]
        private List<IInstaller> m_installers = new List<IInstaller>();

        public void Install(IContainerBuilder builder) {
            if (m_installers.Count is 0) {
                return;
            }
            
            m_installers.ForEach(x => x.Install(builder));
        }
    }
}