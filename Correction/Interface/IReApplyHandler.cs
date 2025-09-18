using System;

namespace GeneralModule.Correction.Interface {
    public interface IReApplyHandler {
        
        Action ReapplyEvent { get; set; }
        
    }
}