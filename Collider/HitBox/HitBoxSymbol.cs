using GeneralModule.Collider.HitBox.Interface;
using GeneralModule.Collider.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GeneralModule.Collider.HitBox
{
    public class HitBoxSymbol : SerializedMonoBehaviour , IHitBoxSymbol
    {
        public GameObject Instance => gameObject;

        [OdinSerialize, LabelText("接触中のシンボル")]
        protected List<IColliderSymbol> m_onCollisionSymbols = new();

        [SerializeField, LabelText("接触時のコールバック")]
        protected UnityEvent<Collision> onCollisionUEvent;
        
        [SerializeField, LabelText("接触解除時のコールバック")]
        protected UnityEvent<Collision> onLeaveCollisionUEvent;

        public void OnCollisionEnter(Collision collision)
        {
            onCollisionUEvent?.Invoke(collision);
        }

        public void OnCollisionExit(Collision collision)
        {
            onLeaveCollisionUEvent?.Invoke(collision);
        }
    }
}