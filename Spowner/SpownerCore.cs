using GeneralModule.Spowner.Data.Interface;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using VContainer;
using VContainer.Unity;

namespace GeneralModule.Spowner {
    /// <summary>
    /// 
    /// </summary>
    public class SpownerCore : SerializedMonoBehaviour {

        [OdinSerialize, LabelText("")]
        protected IObjectResolver resolver;

        public void Spown (ISpownerData data) {

            if (data is null) {
                throw new System.ArgumentNullException ("data");
            }


            resolver.Instantiate(
                data.Prefab,
                data.Position.Position(gameObject),
                data.Rotation.Rotation(gameObject)
                );
        }
    }
}