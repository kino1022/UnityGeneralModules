using GeneralModule.Installer.List.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Installer.List {

    public class InstallerList :SerializedMonoBehaviour, IInstallerList {

        [OdinSerialize, LabelText("インストーラー")]
        protected List<IInstaller> m_installers;

        public void Install(IContainerBuilder builder) {

            m_installers.ForEach(x => {
                x?.Install(builder);
            });
        }
    }
}