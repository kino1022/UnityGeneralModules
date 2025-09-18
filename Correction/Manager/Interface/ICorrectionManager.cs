using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.List.Interface;
using System;
using System.Collections.Generic;

namespace GeneralModule.Correction.Manager.Interface {
    /// <summary>
    /// ����v�f�ɂ�����␳�l���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ICorrectionManager : IDisposable {
        
        IReadOnlyList<ICorrectionInstance> Corrections { get; }

        void Add(ICorrectionInstance instance);

        void Remove(ICorrectionInstance instance);

        float Apply(float value);
    }
}