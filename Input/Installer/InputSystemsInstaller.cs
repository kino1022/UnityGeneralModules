using GeneralModule.Input.InputWrapper;
using GeneralModule.Input.InputWrapper.Interface;
using GeneralModule.Input.Provider;
using GeneralModule.Input.Provider.Interface;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Input.Installer {
    public class InputSystemsInstaller : IInstaller {

        public void Install(IContainerBuilder builder) {
            
            builder.RegisterInstance(new PlayerInputActions()).AsSelf();
            
            builder.Register<IInputActionProvider, InputActionProvider>(Lifetime.Singleton).As<IInputActionProvider>();
            
            builder.Register<IInputObservableProvider, InputObservableProvider>(Lifetime.Singleton);
            
        }
    }
}