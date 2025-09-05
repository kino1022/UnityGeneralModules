using GeneralModule.Installer.List;
using GeneralModule.Installer.List.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UnityGeneralModules.Scope {
    
    public class ListableLifetimeScope : LifetimeScope {

        [SerializeField, LabelText("インストーラーのリスト")]
        protected InstallerList m_list;

        protected override void Configure(IContainerBuilder builder) {
            base.Configure(builder);

            if (m_list is null) {
                return;
            }
            
            m_list.Install(builder);
        }
    }
}