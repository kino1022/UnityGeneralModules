using GeneralModule.Input.Operator;
using R3;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace GeneralModule.Input.Asset.Cell.Template {
    [CreateAssetMenu(menuName = "GeneralModule/Input/Cell/MultiTap")]
    public class MultiTapThrottleInputCell : AInputContextCell {

        [TitleGroup("“ü—Í")]
        [SerializeField]
        [LabelText("“ü—Í‰ñ”")]
        private int m_tapAmount = 2;

        [TitleGroup("“ü—Í")]
        [SerializeField]
        [LabelText("“ü—Í—P—\")]
        [ProgressBar(0, 1000)]
        private int m_multiTapGrace;

        protected override void InputContext() {
            m_primaryInput
                .TapOnCount(2, TimeSpan.FromMilliseconds(m_multiTapGrace))
                .SelectMany(x => {
                    return Observable
                    .ReturnUnit()
                    .Delay(TimeSpan.FromMilliseconds(m_multiTapGrace))
                    .TakeUntil(m_cancelStream);
                });
        }
    }
}