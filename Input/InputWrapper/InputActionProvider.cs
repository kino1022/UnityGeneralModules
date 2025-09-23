using System;
using System.Collections;
using System.Collections.Generic;
using GeneralModule.Input.InputWrapper.Interface;
using UnityEngine.InputSystem;
using VContainer;

namespace GeneralModule.Input.InputWrapper{
    public class InputActionProvider : IInputActionProvider {
        
        private readonly PlayerInputActions m_actions;

        [Inject]
        public InputActionProvider(PlayerInputActions actions) {
            m_actions = actions ?? throw new ArgumentNullException(nameof(actions));
        }

        public void Dispose() {
            m_actions.Dispose();
        }
        
        public void Enable() => m_actions.Enable();
        
        public void Disable() => m_actions.Disable();
        
        public InputAction FindAction(string actionName) => m_actions.FindAction(actionName);
        
        public IEnumerator<InputAction> GetEnumerator() => m_actions.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator() => m_actions.GetEnumerator();
    }
}