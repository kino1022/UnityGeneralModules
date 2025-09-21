using GeneralModule.Status.Assets.Health.EventBus.Interface;
using GeneralModule.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Status.Assets.Health.EventBus {
    public class OnDeathEventBus : IOnDeathEventBus {

        protected GameObject m_obj;
        
        public GameObject Obj => m_obj;

        public OnDeathEventBus(GameObject obj) {

            if (obj == null) {
                throw new System.ArgumentNullException(nameof(obj));
            }
            
            m_obj = obj;
        }
    }
}