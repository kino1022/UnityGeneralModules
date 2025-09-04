using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using System;
using System.Collections.Generic;

namespace GeneralModule.Correction.List.Interface {
    /// <summary>
    /// �␳�l���^�C�v���ƂɊǗ����郊�X�g��S���N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
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