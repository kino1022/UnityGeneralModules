using GeneralModule.Correction.Definition.Type;
using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.List;
using GeneralModule.Correction.Observable.List.Interface;
using ObservableCollections;
using System;

namespace GeneralModule.Correction.Observable.List {
    [Serializable]
    public class ObservableCorrectionList : CorrectionList , IObservableCorrectionList {

        

        public Action CorrectionChangeEvent { get; set; }

        public ObservableCorrectionList(CorrectionType type, ICorrectionTypePropertyProvider provider) : base(type, provider) {
            RegisterCorrections();
        }
        
        public void RegisterCorrections() {
            
        }
    }
}