using GeneralModule.Input.Signal;
using R3;
using UnityEngine.InputSystem;

namespace GeneralModule.Input.Provider.Interface {
    
    public interface IInputObservableProvider {
        
        Observable<InputSignal> GetStream (InputAction action);

        Observable<InputSignal> GetStream(InputActionReference actionReference);

    }
}