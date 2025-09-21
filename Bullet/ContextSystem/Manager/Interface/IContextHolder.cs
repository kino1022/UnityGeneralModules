using System;
using System.Collections.Generic;
using GeneralModule.Bullet.ContextSystem.Context.Interface;
using ObservableCollections;

namespace GeneralModule.Bullet.ContextSystem.Manager.Interface {
    public interface IContextHolder {
        
        IReadOnlyObservableList<IContext> Contexts { get; }
        
        void Add (IContext context);
        
        void Remove (IContext context);
    }
}