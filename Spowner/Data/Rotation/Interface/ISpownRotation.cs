using UnityEngine;

namespace GeneralModule.Spowner.Data.Rotation.Interface {
    /// <summary>
    /// スポナーで出現した際の回転を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ISpownRotation {
        Quaternion Rotation(GameObject spowner);
    }
}