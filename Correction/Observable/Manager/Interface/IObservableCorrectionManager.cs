using GeneralModule.Correction.Manager.Interface;
using System;

namespace GeneralModule.Correction.Observable.Manager.Interface {
    /// <summary>
    /// 補正値の値の変化を常時出来るICorrectionManagerに対して約束するインターフェース
    /// </summary>
    public interface IObservableCorrectionManager : ICorrectionManager {
        /// <summary>
        /// 補正値の値が変化した際に発火される
        /// </summary>
        Action ChangeCorrectionEvent { get; }
    }
}