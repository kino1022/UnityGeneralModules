using GeneralModule.Input.Asset.Cell.Interface;
using GeneralModule.Input.Provider.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;
using System;
using VContainer;

namespace GeneralModule.Input.Asset.Table {
    public class InputControllTable : SerializedMonoBehaviour {

        [OdinSerialize]
        [LabelText("—LŒø‰»‚³‚ê‚½“ü—Í")]
        private List<IInputContextCell> m_cells = new();

        private IObjectResolver m_resolver;

        private IInputObservableProvider m_provider;

        [Inject]
        public void Construct (IObjectResolver resolver) {
            m_resolver = resolver ?? throw new System.ArgumentNullException();
        }

        private void Start() {
            m_provider = m_resolver.Resolve<IInputObservableProvider>()
                ?? throw new NullReferenceException();

            m_cells.ForEach(x => x?.Start());
            m_cells.ForEach(x => x?.RegisterInput(m_provider));
        }

        private void OnDestroy() {
            m_cells.ForEach(x => x.Dispose());
        }
    }
}