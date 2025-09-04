using GeneralModule.Correction.Definition.Type.Interface;
using System;

namespace GeneralModule.Correction.Instance.Interface {
    /// <summary>
    /// 補正値の値を表現するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICorrectionInstance : IDisposable {

        float Value { get; }

        ICorrectionType Type { get; }

    }
}