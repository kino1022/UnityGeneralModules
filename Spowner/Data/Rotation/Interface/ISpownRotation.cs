using UnityEngine;

namespace GeneralModule.Spowner.Data.Rotation.Interface {
    /// <summary>
    /// �X�|�i�[�ŏo�������ۂ̉�]���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ISpownRotation {
        Quaternion Rotation(GameObject spowner);
    }
}