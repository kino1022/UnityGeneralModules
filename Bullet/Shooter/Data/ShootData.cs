using GeneralModule.Bullet.Symbol;
using GeneralModule.Shooter.Data.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Bullet.Shooter.Data {
    [CreateAssetMenu(menuName = "GeneralModule/Bullet/Shooter/ShootData")]
    public class ShootData : SerializedScriptableObject , IShootData {

        [OdinSerialize, LabelText("生成する弾丸")] 
        protected BulletSymbol m_bullet;
        
        [SerializeField, LabelText("射出する方向")]
        protected Vector3 m_direction;
        
        [SerializeField, LabelText("縦方向への精度"),ProgressBar(0.0f,1.0f)]
        protected float m_verticalAccuracy;
        
        [SerializeField, LabelText("横方向への精度"), ProgressBar(0.0f, 1.0f)]
        protected float m_horizontalAccuracy;
        
        public BulletSymbol Bullet => m_bullet;
        
        public Vector3 Direction => m_direction;
        
        public float VerticalAccuracy => m_verticalAccuracy;
        
        public float HorizontalAccuracy => m_horizontalAccuracy;
        
    }
}