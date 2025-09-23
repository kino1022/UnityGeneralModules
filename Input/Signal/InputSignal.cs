using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine.InputSystem;

namespace GeneralModule.Input.Signal {
    public record InputSignal (InputActionPhase Phase, float Value, double Time);
}