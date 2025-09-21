using System;
using GeneralModule.Bullet.ContextSystem.Context.Interface;
using GeneralModule.Bullet.ContextSystem.Manager.Interface;
using ObservableCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GeneralModule.Bullet.ContextSystem.Manager {
    [Serializable]
    public class ContextHolderModule : IContextHolder , IDisposable {
        
        [OdinSerialize, LabelText("管理しているコンテキスト")]
        protected ObservableList<IContext> m_contexts = new ObservableList<IContext>();
        
        public IReadOnlyObservableList<IContext> Contexts => m_contexts;

        public ContextHolderModule() {
            m_contexts = new ObservableList<IContext>();
        }

        public void Dispose() {
            m_contexts.Clear();
        }

        public void Add(IContext context) {
            if (context is null) throw new ArgumentNullException(nameof(context));
            
            m_contexts.Add(context);
        }

        public void Remove(IContext context) {
            if (context is null) throw new ArgumentNullException(nameof(context));
            
            m_contexts.Remove(context);
        }
    }
}