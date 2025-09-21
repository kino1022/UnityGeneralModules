using System;
using GeneralModule.Spawner.Data.Rotation.Interface;
using UnityEngine;

namespace GeneralModule.Spawner.Data.Rotation {
    /// <summary>
    /// Spawnerの向きを引き継ぐISpawnRotation
    /// </summary>
    [Serializable]
    public class TakeSpawnerRotation : ISpawnRotation {

        public UnityEngine.Quaternion Rotation(GameObject spawner) {
            return spawner.transform.rotation;
        }
        
    }
}