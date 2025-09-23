using System;
using GeneralModule.Input.InputWrapper;
using GeneralModule.Input.InputWrapper.Interface;
using GeneralModule.Input.Provider;
using GeneralModule.Input.Provider.Interface;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Input.Installer {
    [Serializable]
    public class InputSystemsInstaller : IInstaller {
        
        [OdinSerialize]
        private PlayerInputActions m_playerActions;

        public void Install(IContainerBuilder builder) {
            
            builder.RegisterInstance(m_playerActions).As<PlayerInputActions>();
            
            builder.Register<IInputActionProvider, InputActionProvider>(Lifetime.Singleton).As<IInputActionProvider>();
            
            builder.Register<IInputObservableProvider, InputObservableProvider>(Lifetime.Singleton);
            
        }
    }
}