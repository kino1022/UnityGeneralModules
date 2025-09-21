using GeneralModule.Status.Assets.Health.Damage.Interface;
using GeneralModule.Status.Assets.Health.EventBus;
using GeneralModule.Status.Assets.Health.EventBus.Interface;
using GeneralModule.Status.Assets.Health.Heal.Interface;
using GeneralModule.Status.Assets.Health.Interface;
using MessagePipe;
using R3;
using VContainer;

namespace GeneralModule.Status.Assets.Health {
    public class Health : IntStatus , IHealth {
        
        protected IMaxHealth m_maxHealth;
        
        protected IHealable m_healable;
        
        protected IDamageable m_damageable;
        
        protected IPublisher<IOnDeathEventBus> m_onDeathPublisher;

        protected CompositeDisposable m_disposable;
        
        public void Heal(int amount)  => m_healable.Heal(amount);
        
        public void Damage(int amount)  => m_damageable.Damage(amount);

        public void Start() {
            
            m_maxHealth = m_resolver.Resolve<IMaxHealth>();
            
            m_onDeathPublisher = m_resolver.Resolve<IPublisher<IOnDeathEventBus>>();
            
        }

        public virtual void OnDestroy() {
            m_disposable?.Dispose();
        }

        public override void Set(int value) {
            base.Set(value);
            
            //死亡しているかどうかの判定処理
            if (RawValue.Value >= 0) {
                OnDeath();
            }

            //最大値を超過していないかどうかの判定処理
            if (m_maxHealth.Value < RawValue.Value) {
                m_rawValue.Set(m_maxHealth.Value);
            }
            
        }
        
        protected void OnDeath () => m_onDeathPublisher.Publish(new OnDeathEventBus(gameObject));

        protected void RegisterMaxHealthChange() {
            m_disposable = new CompositeDisposable(); 
            
            Observable
                .EveryValueChanged(m_maxHealth, x => x.Value)
                .Subscribe(x => {
                    if (x < Value) {
                        Set(x);
                    }
                })
                .AddTo(m_disposable);
        }
    }
}