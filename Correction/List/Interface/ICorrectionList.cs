using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using System;
using System.Collections.Generic;

namespace GeneralModule.Correction.List.Interface {
    /// <summary>
    /// 補正値をタイプごとに管理するリストを担うクラスに対して約束するインターフェース
    /// </summary>
    public interface ICorrectionList : IDisposable {

        ICorrectionType Type { get; }

        IReadOnlyList<ICorrectionInstance> Corrections { get; }

        void Add (ICorrectionInstance instance);

        void Remove (ICorrectionInstance instance);

        void Clear ();

        float Apply(float value);


    }
}