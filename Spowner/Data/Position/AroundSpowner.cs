using GeneralModule.Spowner.Data.Position.Interface;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace GeneralModule.Spowner.Data.Position {
    /// <summary>
    /// スポナーを中心とした円形範囲にスポーンさせる際のISpownPosition
    /// </summary>
    [Serializable, LabelText("スポーン位置：円形範囲")]
    public class AroundSpowner : ISpownPosition {

        [SerializeField, LabelText("半径"),ProgressBar(0.0f,500.0f)]
        protected float m_radius = 1.0f;

        [SerializeField]
        [LabelText("高さ")]
        [ProgressBar(0.0f,50.0f)]
        protected float m_height = 2.0f;

        public Vector3 Position(GameObject spowner) {
            var circle = UnityEngine.Random.insideUnitCircle;
            var randompoint = new Vector2(spowner.transform.position.x,spowner.transform.position.z) + circle * m_radius;
            
            var height = UnityEngine.Random.Range(0,m_height);
            return new Vector3(randompoint.x, height, randompoint.y);
        }
    }
}