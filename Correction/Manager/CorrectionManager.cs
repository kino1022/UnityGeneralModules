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

        public CorrectionManager() {

        }

        public void Dispose () {
            ///管理下のリストの終了処理
            Lists.ForEach(list => list.Dispose());
            Lists.ForEach(list => list = null);
        }

        public void Add (ICorrectionInstance instance) {

            if (instance is null || instance.Type is null) {
                throw new ArgumentNullException(nameof(instance));
            }

            var list = Lists.First(x => x.Type.GetType() == instance.Type.GetType());

            if (list is null) {
                list = CreateNewList(instance.Type);
            }

            list.Add(instance);
        }

        public void Remove (ICorrectionInstance instance) {

            if (instance is null || instance.Type is null) {
                throw new ArgumentNullException(nameof(instance));
            }

            var list = Lists.First(x => x.Type.GetType() == instance.Type.GetType());

            if (list is null) {
                throw new NullReferenceException();
            }

            list.Remove(instance);
        }

        public float Apply (float value) {

            if (Lists.Count is 0) {
                return value;
            }

            var processTree = Lists.OrderBy(x => x.Type.Priority);

            var result = value;

            processTree.ForEach(x => value = x.Apply(value));

            return result;
        }

        protected ICorrectionList GetListFromType (ICorrectionType type) {
            return Lists.First(x => x.Type.GetType() == type.GetType());
        }

        protected ICorrectionList CreateNewList (ICorrectionType type) {
            if (type is null) {
                throw new ArgumentNullException (nameof(type));
            }

            return m_listFactory.Create(type);
        }
    }
}