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
        
        public BulletSymbol Bullet => m_bullet;
    }
}