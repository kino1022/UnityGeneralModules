using GeneralModule.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Collider.Interface
{
    /// <summary>
    /// ��炢�����U�����蓙�̃Q�[���I�u�W�F�N�g�ɑ΂��ăA�^�b�`����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface IColliderSymbol : ISymbol
    {
        GameObject Instance { get; }
    }
}