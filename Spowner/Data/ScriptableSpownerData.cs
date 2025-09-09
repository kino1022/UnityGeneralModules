
using GeneralModule.Spawner.Data.Interface;
using GeneralModule.Spawner.Data.Position.Interface;
using GeneralModule.Spawner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Spawner.Data {
    [CreateAssetMenu(menuName = "GeneralModule/Spawner/SpawnData/Normal")]
    public class ScriptableSpawnerData : SerializedScriptableObject , ISpawnerData {

        [SerializeField]
        protected ASerializedSymbol m_prefab;

        [OdinSerialize]
        protected ISpawnPosition m_pos;

        [OdinSerialize]
        protected ISpawnRotation m_rot;

        public ASerializedSymbol Prefab => m_prefab;

        public ISpawnPosition Position => m_pos;

        public ISpawnRotation Rotation => m_rot;
    }
}