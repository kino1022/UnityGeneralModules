using System.Collections.Generic;
using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;

namespace GeneralModule.Correction.Manager {
    public class CorrectionManagerBehaviour : SerializedMonoBehaviour , ICorrectionManager {

        [OdinSerialize]
        private ICorrectionManager m_CorrectionManager;

        public IReadOnlyList<ICorrectionInstance> Corrections => m_CorrectionManager.Corrections;

        [Inject]
        public void Construct(ICorrectionManager correctionManager) {
            m_CorrectionManager = correctionManager ?? throw new System.ArgumentNullException(nameof(correctionManager));
        }

        public void Start() {
            //dummy Startable
        }
        
        public void Dispose() {
            m_CorrectionManager?.Dispose();
        }

        [Button("補正値の追加")]
        public void Add(ICorrectionInstance instance) => m_CorrectionManager.Add(instance);
        
        [Button("補正値の追加")]
        public void Remove(ICorrectionInstance instance) => m_CorrectionManager.Remove(instance);

        public float Apply(float value) => m_CorrectionManager.Apply(value);
    }
}