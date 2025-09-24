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

        [TitleGroup("入力")]
        [OdinSerialize]
        [LabelText("入力")]
        private InputActionReference m_actionRef;

        [TitleGroup("キャンセル")]
        [OdinSerialize]
        private List<IInputContextCell> m_cancelInputs = new List<IInputContextCell>();

        [TitleGroup("キャンセル")]
        [SerializeField]
        [LabelText("キャンセル入力受け付け猶予")]
        [ProgressBar(0, 1000)]
        protected int m_cancelGrace = 200;

        [TitleGroup("参照")]
        [LabelText("入力成立時コールバック")]
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
        /// m_primaryInputに対して具体的な入力内容を修飾するメソッド
        /// </summary>
        protected abstract void InputContext();

        /// <summary>
        /// キャンセル用のストリームを生成するメソッド
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