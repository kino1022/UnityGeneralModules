using GeneralModule.Bullet.Symbol;
using GeneralModule.Bullet.Symbol.Interface;

namespace GeneralModule.Shooter.Data.Interface {
    /// <summary>
    /// 射撃時に読み込むデータのクラスに対して約束するインターフェース
    /// </summary>
    public interface IShootData {
        /// <summary>
        /// 生成する弾丸
        /// </summary>
        BulletSymbol Bullet { get; }
    }
}