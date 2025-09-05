using GeneralModule.Spowner.Data.Position.Interface;
using GeneralModule.Spowner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using GeneralModule.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Spowner.Data.Interface {
    /// <summary>
    /// ISpownerCore.Spownでスポーンさせる際の内容を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpownerData {

        ASerializedSymbol Prefab { get; }

        ISpownPosition Position { get; }

        ISpownRotation Rotation { get; }

    }
}