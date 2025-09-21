using System;
using GeneralModule.Status.Assets.Health.Interface;
using VContainer;

namespace GeneralModule.Status.Assets.Health.Damage {
    [Serializable]
    public class DamageModule {
        
        protected IHealth m_health;

        [Inject]
        public DamageModule(IHealth health) {
            m_health = health ?? throw new ArgumentNullException();
        }

        public void Damage(int amount) {
            m_health.Decrease(amount);
        }
    }
}