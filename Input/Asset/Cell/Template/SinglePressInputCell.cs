using GeneralModule.Input.Operator;
using R3;
using System;
using UnityEngine;

namespace GeneralModule.Input.Asset.Cell.Template {
    [CreateAssetMenu(menuName ="GeneralModule/Inptu/Cell/Press")]
    public class SinglePressInputCell : AInputContextCell {

        protected override void InputContext() {
            m_primaryInput
                .OnPressed()
                .SelectMany(x => {
                    return Observable
                    .ReturnUnit()
                    .Delay(TimeSpan.FromMilliseconds(m_cancelGrace))
                    .TakeUntil(m_cancelStream);
                });
        }
    }
}