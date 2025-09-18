using GeneralModule.Correction.Manager.Interface;
using GeneralModule.Status.Value.Interface;

namespace GeneralModule.Status.Interface {
    public interface ICorrectableStatus<Type> : IStatus<Type> {

        IValueModule<Type> CorrectedValue { get; }
        
        ICorrectionManager Corrector { get; }
        
    }
}