using System;
using System.Collections.Generic;
using GeneralModule.Input.InputWrapper.Interface;
using GeneralModule.Input.Provider.Interface;
using GeneralModule.Input.Signal;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Input.Provider {
    [Serializable]
    public class InputObservableProvider : IInputObservableProvider , IInitializable {

        private readonly IInputActionProvider m_actions;

        private readonly Dictionary<Guid, Observable<InputSignal>> m_streamCache = new();

        [Inject]
        public InputObservableProvider(IInputActionProvider actions) {
            m_actions = actions ?? throw new ArgumentNullException(nameof(actions));
        }
        
        public void Initialize() {
            m_actions.Enable();
        }
        
        public Observable<InputSignal> GetStream(InputAction action) {
            if (action == null) return Observable.Empty<InputSignal>();

            // InputActionのIDをキーとしてキャッシュを検索
            var actionId = action.id;
            if (m_streamCache.TryGetValue(actionId, out var cachedStream))
            {
                return cachedStream;
            }

            var startedStream =
                Observable.FromEvent<InputAction.CallbackContext>(
                        x => action.started += x,
                        x => action.started -= x
                    )
                    .Select(ctx => new InputSignal(InputActionPhase.Started, ctx.ReadValue<float>(),
                        Time.realtimeSinceStartupAsDouble));

            var performedStream = Observable.FromEvent<InputAction.CallbackContext>(
                    h => action.performed += h,
                    h => action.performed -= h)
                .Select(ctx => new InputSignal(InputActionPhase.Performed, ctx.ReadValue<float>(),
                    Time.realtimeSinceStartupAsDouble));

            var canceledStream = Observable.FromEvent<InputAction.CallbackContext>(
                    h => action.canceled += h,
                    h => action.canceled -= h)
                .Select(ctx => new InputSignal(InputActionPhase.Canceled, ctx.ReadValue<float>(),
                    Time.realtimeSinceStartupAsDouble));


            // キャッシュにない場合は新しいストリームを生成
            var newStream = Observable
                .Merge(startedStream, performedStream, canceledStream)
                .Share();
            
            // 生成したストリームをキャッシュに保存
            m_streamCache[actionId] = newStream;
            return newStream;
        }
        
        public Observable<InputSignal> GetStream(InputActionReference actionReference)
        {
            // actionReferenceがnullまたはactionが設定されていない場合は空のストリームを返す
            return actionReference?.action != null
                ? GetStream(actionReference.action)
                : Observable.Empty<InputSignal>();
        }
    }
}