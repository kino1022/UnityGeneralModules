using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.List.Interface;
using System;
using System.Collections.Generic;

namespace GeneralModule.Correction.Manager.Interface {
    /// <summary>
    /// ある要素にかかる補正値を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICorrectionManager : IDisposable {
        
        IReadOnlyList<ICorrectionList> Lists { get; }

        void Add(ICorrectionInstance instance);

        void Remove(ICorrectionInstance instance);

        float Apply(float value);
    }
}