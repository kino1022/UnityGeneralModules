using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.List.Interface;

namespace GeneralModule.Correction.List.Factory.Interface {

    public interface ICorrectionListFactory {

        ICorrectionList Create (ICorrectionType type);

    }
}