using GeneralModule.Symbol.Interface;
using Sirenix.OdinInspector;

namespace GeneralModule.Symbol {
    /// <summary>
    /// ISymbolをPrefabデータとして扱うために用いるコンポーネントの基底クラス
    /// </summary>
    public abstract class ASerializedSymbol : SerializedMonoBehaviour, ISymbol {
        
    }
}