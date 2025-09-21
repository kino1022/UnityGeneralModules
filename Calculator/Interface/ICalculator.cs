using UnityEngine;

namespace GeneralModule.Calculator.Interface {
    /// <summary>
    /// ジェネリクスで値型を扱う際に利用する糖衣演算用クラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="Type">利用する値型</typeparam>
    public interface ICalculator<Type> {
       
        Type Add (Type a, Type b);
        
        Type Add(Type[] values);
        
        Type Subtract(Type a, Type b);
        
        Type Subtract(Type[] values);
        
        Type Multiply(Type a, Type b);
        
        Type Multiply(Type[] values);
        
        Type Divide(Type a, Type b);
        
        /// <summary>
        ///  a == b であることを返す
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool Equal(Type a, Type b);
        
        /// <summary>
        /// a > b であるかどうかを返す
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool Greater (Type a, Type b);
        
        /// <summary>
        /// a < bであるかどうかを返す
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool Less (Type a, Type b);

        /// <summary>
        /// 0に当たる値を返す
        /// </summary>
        Type Zero { get; }
        
        /// <summary>
        /// -1に当たる値を返す
        /// </summary>
        Type Minus { get; }
        
    }
}