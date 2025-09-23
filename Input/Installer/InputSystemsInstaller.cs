using VContainer;
using VContainer.Unity;

namespace System.Runtime.CompilerServices.Input.Installer {
    public class InputSystemsInstaller : IInstaller {

        public void Install(IContainerBuilder builder) {

            builder.RegisterInstance(new PlayerInputActions()).AsSelf();
            
            builder.
        }
    }
}