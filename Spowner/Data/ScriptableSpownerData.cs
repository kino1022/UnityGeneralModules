
using GeneralModule.Spowner.Data.Interface;
using GeneralModule.Spowner.Data.Position.Interface;
using GeneralModule.Spowner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Spowner.Data {
    [CreateAssetMenu(menuName = "GeneralModule/Spowner/SpownData")]
    public class ScriptableSpownerData : SerializedScriptableObject , ISpownerData {

        [SerializeField]
        protected ASerializedSymbol m_prefab;

        [OdinSerialize]
        protected ISpownPosition m_pos;

        [OdinSerialize]
        protected ISpownRotation m_rot;

        public ASerializedSymbol Prefab => m_prefab;

        public ISpownPosition Position => m_pos;

        public ISpownRotation Rotation => m_rot;
    }
}