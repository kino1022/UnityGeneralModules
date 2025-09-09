using UnityEngine;

namespace GeneralModule.Spawner.Data.Rotation.Interface {
    /// <summary>
    /// �X�|�i�[�ŏo�������ۂ̉�]���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ISpawnRotation {
        Quaternion Rotation(GameObject spawner);
    }
}