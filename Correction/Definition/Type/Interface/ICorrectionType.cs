using GeneralModule.Correction.Instance.Interface;
using System.Collections.Generic;

namespace GeneralModule.Correction.Definition.Type.Interface {
    /// <summary>
    /// �v�Z���@����Ƃ����␳�l�̕��ނ�\������N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ICorrectionType {

        int Priority { get; }

        float Apply(float value, List<ICorrectionInstance> corrections);
    }
}