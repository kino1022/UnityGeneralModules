using System;
using VContainer.Unity;
using R3;
using GeneralModule.Input.Signal;
using UnityEngine;
using UnityEngine.Events;
using GeneralModule.Input.Provider.Interface;

namespace GeneralModule.Input.Asset.Cell.Interface {
    public interface IInputContextCell : IStartable , IDisposable {

        /// <summary>
        /// ���͂����������ۂ̃R�[���o�b�N
        /// </summary>
        UnityEvent<InputSignal> OnInput { get; }
        
        /// <summary>
        /// ���͂����������ۂɔ��΂����Observable
        /// </summary>
        Observable<InputSignal> Signal { get; }

        /// <summary>
        /// ���͂𑼂̃X�g���[���֓`�B���邽�߂�Observable
        /// </summary>
        Observable<Unit> Stream { get; }

        /// <summary>
        /// �X�g���[���𐶐����ē��͂��Ď�����
        /// </summary>
        /// <param name="provider"></param>
        void RegisterInput(IInputObservableProvider provider);

    }
}