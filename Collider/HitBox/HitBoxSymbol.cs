using GeneralModule.Collider.HitBox.Interface;
using GeneralModule.Collider.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeneralModule.Collider.HitBox
{
    public class HitBoxSymbol : SerializedMonoBehaviour , IHitBoxSymbol
    {
        public GameObject Instance => gameObject;

        [OdinSerialize, LabelText("接触中のシンボル")]
        protected List<IColliderSymbol> m_onCollisionSymbols = new();

        public void OnCollisionEnter(Collision collision)
        {
            
        }

        public void OnCollisionExit(Collision collision)
        {

        }
    }
}