using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GeneralModule.Spawner.Data.Interface;
using GeneralModule.Spawner.Pattern.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GeneralModule.Spawner.Pattern {
    [Serializable]
    public class RegularIntervalPattern : ISpawnPattern {

        [OdinSerialize, LabelText("スポーンさせるデータ")]
        protected ISpawnerData m_data;

        [SerializeField, LabelText("インターバル")]
        protected float m_interval = 0;
        
        public Action<ISpawnerData> OnSpawnTiming { get; set; }

        protected CancellationTokenSource m_cts;
        
        public void Start() {
            m_cts = new();
            CancellationToken token = m_cts.Token;
        }

        public void Dispose() {
            m_cts.Cancel();
        }

        protected async UniTask CountInterval() {
            
        }
    }
}