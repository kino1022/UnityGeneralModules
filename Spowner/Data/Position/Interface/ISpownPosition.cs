using System.Numerics;
using UnityEngine;

namespace GeneralModule.Spowner.Data.Position.Interface {
    /// <summary>
    /// スポーンさせる座標を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpownPosition {

        UnityEngine.Vector3 Position(GameObject spowner);

    }
}