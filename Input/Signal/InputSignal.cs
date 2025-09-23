using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GeneralModule.Input.Signal {
    public record InputSignal (InputActionPhase Phase, float Value, double Time);

    public static class InputSignalExtensions {
        public static void PublishSignalInfo(this InputSignal signal) {
            Debug.Log($"actionPhase: {signal.Phase}, value: {signal.Value}, time: {signal.Time}");
        }
    }
}