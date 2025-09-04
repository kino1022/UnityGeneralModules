using System;

namespace GeneralModule.Correction.Definition.Type.Interface {
    /// <summary>
    /// 他のクラスに対して補正値分類の参照を渡すクラスに対して約束するインターフェース
    /// </summary>
    public interface ICorrectionTypeProvider : IDisposable {

        ICorrectionType Provide(ICorrectionType type);

    }
}