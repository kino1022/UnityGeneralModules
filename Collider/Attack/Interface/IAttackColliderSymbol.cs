using GeneralModule.Collider.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace GeneralModule.Collider.Attack.Interface
{
    /// <summary>
    /// �U������̃V���{���ɂȂ�R���|�[�l���g�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface IAttackColliderSymbol : IColliderSymbol
    {

        UnityEvent<IColliderSymbol> OnHitUEvent { get; }

        UnityEvent<IColliderSymbol> OnLeaveUEvent { get; }

    }
}