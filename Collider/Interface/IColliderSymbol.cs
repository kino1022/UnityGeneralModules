using GeneralModule.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Collider.Interface
{
    /// <summary>
    /// 喰らい判定や攻撃判定等のゲームオブジェクトに対してアタッチするクラスに対して約束するインターフェース
    /// </summary>
    public interface IColliderSymbol : ISymbol
    {
        GameObject Instance { get; }
    }
}