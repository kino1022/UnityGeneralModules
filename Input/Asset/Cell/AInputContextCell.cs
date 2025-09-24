using GeneralModule.Input.Asset.Cell.Interface;
using GeneralModule.Input.Signal;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using R3;
using GeneralModule.Input.Provider.Interface;
using System.Linq;
using Sirenix.Utilities;

namespace GeneralModule.Input.Asset.Cell {
    public abstract class AInputContextCell : SerializedScriptableObject, IInputContextCell {

        [TitleGroup("����")]
        [OdinSerialize]
        [LabelText("����")]
        private InputActionReference m_actionRef;

        [TitleGroup("�L�����Z��")]
        [OdinSerialize]
        private List<IInputContextCell> m_cancelInputs = new List<IInputContextCell>();

        [TitleGroup("�L�����Z��")]
        [SerializeField]
        [LabelText("�L�����Z�����͎󂯕t���P�\")]
        [ProgressBar(0, 1000)]
        protected int m_cancelGrace = 200;

        [TitleGroup("�Q��")]
        [LabelText("���͐������R�[���o�b�N")]
        public UnityEvent<InputSignal> OnInput { get; protected set; }

        protected Observable<InputSignal> m_primaryInput;

        protected Observable<InputSignal> m_signal;

        protected Observable<Unit> m_cancelStream;

        public Observable<InputSignal> Signal => m_signal;

        public Observable<Unit> Stream => Signal.Select(_ => Unit.Default);

        public void Start() {

            if (m_actionRef is null) {
                throw new NullReferenceException();
            }

            m_actionRef.action.Enable();

        }

        public void Dispose () {
            m_actionRef.action?.Dispose();
        }


        public void RegisterInput (IInputObservableProvider provider) {
            m_primaryInput = provider.GetStream(m_actionRef) ?? throw new NullReferenceException();

            m_cancelStream = CreateCancelStream();

            InputContext();

            OnInputCompleted();
        }

        /// <summary>
        /// m_primaryInput�ɑ΂��ċ�̓I�ȓ��͓��e���C�����郁�\�b�h
        /// </summary>
        protected abstract void InputContext();

        /// <summary>
        /// �L�����Z���p�̃X�g���[���𐶐����郁�\�b�h
        /// </summary>
        /// <returns></returns>
        private Observable<Unit> CreateCancelStream () {

            if (m_cancelInputs is null || m_cancelInputs.Count is 0) {
                return Observable.Empty<Unit>();
            }

            var result = Observable
                .ReturnUnit();
            var cancel = m_cancelInputs
                .Select(x => x.Stream)
                .ForEach(x => result.Merge(x));

            return result;
        }

        private void OnInputCompleted () {
            Signal
                .Subscribe(_ => OnInput?.Invoke(_));
        }
    }
}