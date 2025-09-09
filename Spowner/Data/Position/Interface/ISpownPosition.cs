using System.Numerics;
using UnityEngine;

namespace GeneralModule.Spawner.Data.Position.Interface {
    /// <summary>
    /// �X�|�[����������W���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ISpawnPosition {

        UnityEngine.Vector3 Position(GameObject spowner);

    }
}