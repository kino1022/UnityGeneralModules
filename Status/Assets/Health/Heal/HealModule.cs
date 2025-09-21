using System;
using GeneralModule.Status.Assets.Health.Interface;
using VContainer;

namespace GeneralModule.Status.Assets.Health.Heal {
    [Serializable]
    public class HealModule {
        
        protected IHealth m_health;

        [Inject]
        public HealModule(IHealth health) {
            m_health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public void Heal(int amount) {
            m_health.Increase(amount);
        }
        
    }
}