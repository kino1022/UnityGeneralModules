using System;

namespace GeneralModule.Bullet.ContextSystem.Manager.Interface {
    public interface IHolderRegister {
        
        void RegisterHolder (IContextHolder holder);
        
        void UnregisterHolder (IContextHolder holder);
        
    }
}