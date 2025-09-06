using GeneralModule.Lottery.Table.Interface;
using GeneralModule.Spowner.Data.Interface;
using GeneralModule.Spowner.Data.Position.Interface;
using GeneralModule.Spowner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Spowner.Data {
    [CreateAssetMenu(menuName = "GeneralModule/Spowner/SpownData/Table")]
    public class TableSpownData : SerializedScriptableObject, ISpownerData {

        [OdinSerialize, LabelText("スポーンテーブル")]
        protected ILotteryTable<ASerializedSymbol> m_table;

        [OdinSerialize,LabelText("")]
        protected ISpownPosition m_pos;

        [OdinSerialize, LabelText("")]
        protected ISpownRotation m_rot;

        public ASerializedSymbol Prefab => m_table.Lottery();

        public ISpownPosition Position => m_pos;

        public ISpownRotation Rotation => m_rot;
    }
}