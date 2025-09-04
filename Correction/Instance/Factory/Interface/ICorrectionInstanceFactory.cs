using GeneralModule.Correction.Instance.Interface;
using System;

namespace GeneralModule.Correction.Instance.Factory.Instance {
    public interface ICorrectionInstanceFactory : IDisposable {
        ICorrectionInstance Create();
    }
}