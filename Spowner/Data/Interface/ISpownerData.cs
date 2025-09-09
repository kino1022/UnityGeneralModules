using GeneralModule.Spawner.Data.Position.Interface;
using GeneralModule.Spawner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using GeneralModule.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Spawner.Data.Interface {
    /// <summary>
    /// ISpownerCore.Spown�ŃX�|�[��������ۂ̓��e���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ISpawnerData {

        ASerializedSymbol Prefab { get; }

        ISpawnPosition Position { get; }

        ISpawnRotation Rotation { get; }

    }
}