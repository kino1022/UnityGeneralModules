using GeneralModule.Correction.Definition.Type;
using GeneralModule.Correction.Definition.Type.Interface;
using GeneralModule.Correction.Instance.Interface;
using GeneralModule.Correction.List.Factory.Interface;
using GeneralModule.Correction.List.Interface;
using GeneralModule.Correction.Manager.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace GeneralModule.Correction.Manager {

    [Serializable]
    public class CorrectionManager : ICorrectionManager {

        [TitleGroup("補正値")]
        [OdinSerialize, LabelText("管理されている補正値")]
        protected List<ICorrectionList> m_lists;

        public IReadOnlyList<ICorrectionList> Lists => m_lists;

        [TitleGroup("参照")]
        [OdinSerialize, LabelText("リスト生成クラス")]
        protected ICorrectionListFactory m_listFactory;

        [TitleGroup("参照")]
        [OdinSerialize, LabelText("プロパティプロバイダー")]
        protected ICorrectionTypePropertyProvider m_propertyProvider;

        protected IObjectResolver m_resolver;

        [Inject]
        public CorrectionManager(IObjectResolver resolver) {
            m_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public void Dispose () {
            ///管理下のリストの終了処理
            Lists.ForEach(list => list.Dispose());
            Lists.ForEach(list => list = null);
        }

        public void Add (ICorrectionInstance instance) {

            if (instance is null) {
                throw new ArgumentNullException(nameof(instance));
            }

            var list = Lists.First(x => x.Type.GetType() == instance.Type.GetType());

            if (list is null) {
                list = CreateNewList(instance.Type);
            }

            list.Add(instance);
        }

        public void Remove (ICorrectionInstance instance) {

            if (instance is null) {
                throw new ArgumentNullException(nameof(instance));
            }

            var list = Lists.First(x => x.Type == instance.Type);

            if (list is null) {
                throw new NullReferenceException();
            }

            list.Remove(instance);
        }

        public float Apply (float value) {

            if (Lists.Count is 0) {
                return value;
            }

            var processTree = Lists.OrderBy(x => m_propertyProvider.Provide(x.Type).Priority);

            var result = value;

            processTree.ForEach(x => value = x.Apply(value));

            return result;
        }

        protected ICorrectionList GetListFromType (CorrectionType type) {
            return Lists.First(x => x.Type == type);
        }

        protected ICorrectionList CreateNewList (CorrectionType type) {

            return m_listFactory.Create(type);
        }
    }
}