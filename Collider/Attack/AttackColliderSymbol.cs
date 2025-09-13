using GeneralModule.Collider.Attack.Interface;
using GeneralModule.Collider.Interface;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GeneralModule.Collider.Attack {
    public class AttackColliderSymbol : SerializedMonoBehaviour , IAttackColliderSymbol {

        [SerializeField, LabelText("ヒット時の処理")]
        public UnityEvent<IColliderSymbol> OnHitUEvent {  get; set; }

        [SerializeField, LabelText("ヒット解除時の処理")]
        public UnityEvent<IColliderSymbol> OnLeaveUEvent { get; set; }


        [SerializeField, LabelText("当たり判定の本体")]
        protected GameObject m_Instance;

        public GameObject Instance => m_Instance;

        protected void Awake() {
            if (Instance is null) {
                m_Instance = gameObject;
            }
        }

    }
}