using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Scope {
    
    public class ListableLifetimeScope : LifetimeScope {
        
        [SerializeField]
        [LabelText("MonoInstaller自動取得")]
        private bool m_autoFindInstallers = true;

        [SerializeField, LabelText("インストーラーのリスト")]
        protected InstallerList m_list;

        protected override void Configure(IContainerBuilder builder) {
            base.Configure(builder);

            if (m_list is null) {
                return;
            }
            
            if (m_autoFindInstallers) {
                
                var installers = transform.root.gameObject.GetComponentsInChildren<IInstaller>();

                if (installers.Length > 0) {
                    foreach (var installer in installers) {
                        if (installer is InstallerList) {
                            continue;
                        }

                        installer.Install(builder);
                    }
                }
            }
            
            m_list.Install(builder);
        }
    }
}