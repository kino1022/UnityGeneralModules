using System;
using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using GeneralModule.Correction.Applier.Interface;
using GeneralModule.Correction.Interface;
using VContainer;

namespace GeneralModule.Correction.Manager {
    [Serializable]
    [LabelText("補正値管理クラス")]
    public class CorrectionManager : ICorrectionManager , IReApplyHandler {
        
        [OdinSerialize]
        [LabelText("補正値")]
        protected List<ICorrectionInstance> m_corrections;

        [TitleGroup("参照")]
        [OdinSerialize] [LabelText("補正値適用クラス")] [ReadOnly]
        protected ICorrectionApplyModule m_applier;
        
        protected IObjectResolver m_resolver;
        
        public IReadOnlyList<ICorrectionInstance> Corrections => m_corrections;
        
        public Action ReapplyEvent { get; set; }

        [Inject]
        public CorrectionManager(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));

            m_applier = resolver.Resolve<ICorrectionApplyModule>() ?? throw new ArgumentException();
        }

        public void Dispose() {
            m_corrections.ForEach(x => {
                
                if (x is IReApplyHandler handler) {
                    UnregisterCallBack(handler);
                }

                x.Dispose();
                x = null;
            });
        }
        
        public void Add(ICorrectionInstance correction) {
            if (correction is null) {
                throw new ArgumentNullException(nameof(correction));
            }
            
            m_corrections.Add(correction);

            if (correction is IReApplyHandler handler) {
                RegisterCallBack(handler);
            }
            
            OnReapply();
        }

        public void Remove(ICorrectionInstance correction) {
            
        }

        public float Apply(float value) => m_applier.Apply(value, m_corrections);

        protected void RegisterCallBack(IReApplyHandler handler) {
            ReapplyEvent += handler.ReapplyEvent;
        }

        protected void UnregisterCallBack(IReApplyHandler handler) {
            ReapplyEvent -= handler.ReapplyEvent;
        }

        protected void OnReapply() {
            ReapplyEvent?.Invoke();
        }
    }
}