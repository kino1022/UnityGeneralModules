using GeneralModule.Shooter.Data.Interface;

namespace GeneralModule.Bullet.Shooter.Interface {
    public interface IShootExecutor {

        void Shoot(IShootData data);
    }
}