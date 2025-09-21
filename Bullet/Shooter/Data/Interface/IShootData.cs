using GeneralModule.Bullet.Symbol;
using GeneralModule.Bullet.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Shooter.Data.Interface {
    /// <summary>
    /// 射撃時に読み込むデータのクラスに対して約束するインターフェース
    /// </summary>
    public interface IShootData {
        /// <summary>
        /// 生成する弾丸
        /// </summary>
        BulletSymbol Bullet { get; }
        
        /// <summary>
        /// 弾丸の進行する方向
        /// </summary>
        Vector3 Direction { get; }
        
        /// <summary>
        /// 垂直方向への正確さ
        /// </summary>
        float VerticalAccuracy { get; }
        
        /// <summary>
        /// 水平方向への正確さ
        /// </summary>
        float HorizontalAccuracy { get; }
    }
}