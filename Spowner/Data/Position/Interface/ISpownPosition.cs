using System.Numerics;
using UnityEngine;

namespace GeneralModule.Spowner.Data.Position.Interface {
    /// <summary>
    /// �X�|�[����������W���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ISpownPosition {

        UnityEngine.Vector3 Position(GameObject spowner);

    }
}