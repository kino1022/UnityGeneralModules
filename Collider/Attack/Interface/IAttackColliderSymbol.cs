using GeneralModule.Collider.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace GeneralModule.Collider.Attack.Interface
{
    /// <summary>
    /// 攻撃判定のシンボルになるコンポーネントに対して約束するインターフェース
    /// </summary>
    public interface IAttackColliderSymbol : IColliderSymbol
    {

        UnityEvent<IColliderSymbol> OnHitUEvent { get; }

        UnityEvent<IColliderSymbol> OnLeaveUEvent { get; }

    }
}