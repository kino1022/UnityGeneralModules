using System;
using System.Collections.Generic;
using GeneralModule.Bullet.ContextSystem.Context.Interface;
using GeneralModule.Bullet.ContextSystem.Manager.Interface;
using ObservableCollections;
using R3;
using Sirenix.OdinInspector;

namespace GeneralModule.Bullet.ContextSystem.Manager {
    public class AContextsManager : SerializedMonoBehaviour , IContextManager , IHolderRegister {

        protected Dictionary<IContextHolder, CompositeDisposable> m_holders = new Dictionary<IContextHolder, CompositeDisposable>();

        protected List<IContext> m_context;
        
        public IReadOnlyList<IContext> Contexts => m_context;
        

        public void RegisterHolder(IContextHolder holder) {
            
            var disposable = new CompositeDisposable();
            
            
            holder.Contexts
                .ObserveAdd()
                .Subscribe(x => {
                    OnContextAdded(x);
                })
                .AddTo(disposable);

            holder
                .Contexts
                .ObserveRemove()
                .Subscribe(x => {
                    OnContextRemoved(x);
                })
                .AddTo(disposable);
            
            m_holders.Add(holder, disposable);
        }

        public void UnregisterHolder(IContextHolder holder) {
            
            if (holder is null) throw new ArgumentNullException(nameof(holder));
            
            var disposable = m_holders[holder] ?? throw new NullReferenceException();
            
            disposable.Dispose();
            disposable = null;
            
            m_holders.Remove(holder);
        }

        protected void OnContextAdded(CollectionAddEvent<IContext> x) {
            
            if (x.Value is null) {
                throw new ArgumentNullException(nameof(x.Value));
            }
            
            m_context.Add(x.Value);
        }

        protected void OnContextRemoved(CollectionRemoveEvent<IContext> x) {
            m_context.Remove(x.Value);
        }
    }
}