using System.Collections.Generic;
using GeneralModule.Bullet.ContextSystem.Context.Interface;

namespace GeneralModule.Bullet.ContextSystem.Manager.Interface {
    public interface IContextManager {
        
        IReadOnlyList<IContext> Contexts { get; }
        
    }
}