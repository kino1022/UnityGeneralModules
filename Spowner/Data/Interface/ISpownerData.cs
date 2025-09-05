using GeneralModule.Spowner.Data.Position.Interface;
using GeneralModule.Spowner.Data.Rotation.Interface;
using GeneralModule.Symbol;
using GeneralModule.Symbol.Interface;
using UnityEngine;

namespace GeneralModule.Spowner.Data.Interface {
    /// <summary>
    /// ISpownerCore.Spown�ŃX�|�[��������ۂ̓��e���Ǘ�����N���X�ɑ΂��Ė񑩂���C���^�[�t�F�[�X
    /// </summary>
    public interface ISpownerData {

        ASerializedSymbol Prefab { get; }

        ISpownPosition Position { get; }

        ISpownRotation Rotation { get; }

    }
}