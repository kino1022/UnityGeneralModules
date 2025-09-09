using System;
using System.Collections.Generic;
using GeneralModule.Spawner.Data.Interface;
using GeneralModule.Spawner.Interface;
using GeneralModule.Spawner.Pattern.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Spawner {
    /// <summary>
    /// 
    /// </summary>
    public class SpawnerCore : SerializedMonoBehaviour , ISpawnExecutor {

        [OdinSerialize, LabelText("")]
        protected IObjectResolver resolver;

        [OdinSerialize, LabelText("スポーンタイミング")]
        protected List<ISpawnPattern> m_pattern;
        

        public void Start() {
            if (m_pattern.Count is not 0) {
                m_pattern.ForEach(x => {
                    x.Start();
                    x.OnSpawnTiming += Spawn;
                });
            }
        }
        

        public void OnDestroy() {
            if (m_pattern.Count is not 0) {
                m_pattern.ForEach(x => {
                    x.Dispose();
                    x.OnSpawnTiming -= Spawn;
                });
            }
        }

        public void Spawn (ISpawnerData data) {

            if (data is null) {
                throw new System.ArgumentNullException ("data");
            }


            resolver.Instantiate(
                data.Prefab.gameObject,
                data.Position.Position(gameObject),
                data.Rotation.Rotation(gameObject)
                );
        }
    }
}