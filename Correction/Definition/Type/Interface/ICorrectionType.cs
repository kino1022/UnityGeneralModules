using GeneralModule.Correction.Instance.Interface;
using System.Collections.Generic;

namespace GeneralModule.Correction.Definition.Type.Interface {
    /// <summary>
    /// 計算方法を基準とした補正値の分類を表現するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICorrectionType {

        int Priority { get; }

        float Apply(float value, List<ICorrectionInstance> corrections);
    }
}