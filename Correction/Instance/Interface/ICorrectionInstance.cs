using GeneralModule.Correction.Definition.Type.Interface;
using System;

namespace GeneralModule.Correction.Instance.Interface {
    /// <summary>
    /// �␳�l�̒l��\������N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ICorrectionInstance : IDisposable {

        float Value { get; }

        ICorrectionType Type { get; }

    }
}