using GeneralModule.Status.Assets.Health.Damage.Interface;
using GeneralModule.Status.Assets.Health.Heal.Interface;
using GeneralModule.Status.Interface;

namespace GeneralModule.Status.Assets.Health.Interface {
    
    public interface IHealth : IStatus<int> , IHealable, IDamageable {
        
    }
}