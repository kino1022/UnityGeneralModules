using GeneralModule.Correction.List.Interface;
using System;

namespace GeneralModule.Correction.Observable.List.Interface {
    /// <summary>
    /// 補正値の変化を常時監視出来るクラスに対して約束するインターフェース
    /// </summary>
    public interface IObservableCorrectionList : ICorrectionList {
        Action CorrectionChangeEvent { get; }
    }
}