using GeneralModule.Correction.Instance.Interface;
using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace GeneralModule.Correction.Manager.Interface {
    /// <summary>
    /// ����v�f�ɂ�����␳�l���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ICorrectionManager : IDisposable , IStartable {
        
        IReadOnlyList<ICorrectionInstance> Corrections { get; }

        void Add(ICorrectionInstance instance);

        void Remove(ICorrectionInstance instance);

        float Apply(float value);
    }
}