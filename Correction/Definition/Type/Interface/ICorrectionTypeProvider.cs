using System;

namespace GeneralModule.Correction.Definition.Type.Interface {
    /// <summary>
    /// ���̃N���X�ɑ΂��ĕ␳�l���ނ̎Q�Ƃ�n���N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ICorrectionTypeProvider : IDisposable {

        ICorrectionType Provide(ICorrectionType type);

    }
}