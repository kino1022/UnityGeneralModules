using System;
using GeneralModule.Correction.Applier.Interface;
using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using VContainer;
using System.Collections.Generic;
using System.Linq;
using GeneralModule.Correction.Definition.Type;
using Sirenix.OdinInspector;

namespace GeneralModule.Correction.Applier {
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CorrectionApplyModule : ICorrectionApplyModule {
        
        [TitleGroup("参照")]
        [LabelText("プロパティ供給クラス")]
        [ReadOnly]
        [Inject]
        protected ICorrectionTypePropertyProvider m_propertyProvider;
        

        public float Apply(float value, List<ICorrectionInstance> corrections) {

            if (corrections is null || corrections.Count is 0) {
                return value;
            }
            
            var dic = CreateCorrectionDictionary(corrections);

            var result = value;

            foreach (var pair in dic.OrderBy(x => m_propertyProvider.Provide(x.Key).Priority)) {
                result = m_propertyProvider.Provide(pair.Key).Apply(value,pair.Value);
            }
            
            return result;
        }

        protected Dictionary<CorrectionType, List<ICorrectionInstance>> CreateCorrectionDictionary(
            List<ICorrectionInstance> corrections
            ) 
        {
            
            var result = new Dictionary<CorrectionType, List<ICorrectionInstance>>();
            
            if (corrections.Count is 0) {
                throw new IndexOutOfRangeException();
            }

            foreach (var correction in corrections) {
                if (result.ContainsKey(correction.Type) is false) {
                    result.Add(correction.Type, new List<ICorrectionInstance>());
                }
                result[correction.Type].Add(correction);
            }
            
            return result;
        }
    }
}