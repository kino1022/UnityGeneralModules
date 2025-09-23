using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace GeneralModule.Input.InputWrapper.Interface {
    public interface IInputActionProvider : IEnumerable<InputAction>, IDisposable {
        void Enable();
        void Disable();
        InputAction FindAction(string actionNameOrId);
    }
}