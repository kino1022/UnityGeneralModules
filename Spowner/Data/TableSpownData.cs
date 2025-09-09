using GeneralModule.Lottery.Table.Interface;
using GeneralModule.Spawner.Data.Interface;
using GeneralModule.Spawner.Data.Position.Interface;
using GeneralModule.Spawner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Spawner.Data {
    [CreateAssetMenu(menuName = "GeneralModule/Spawner/SpawnData/Table")]
    public class TableSpawnData : SerializedScriptableObject, ISpawnerData {

        [OdinSerialize, LabelText("スポーンテーブル")]
        protected ILotteryTable<ASerializedSymbol> m_table;

        [OdinSerialize,LabelText("")]
        protected ISpawnPosition m_pos;

        [OdinSerialize, LabelText("")]
        protected ISpawnRotation m_rot;

        public ASerializedSymbol Prefab => m_table.Lottery();

        public ISpawnPosition Position => m_pos;

        public ISpawnRotation Rotation => m_rot;
    }
}