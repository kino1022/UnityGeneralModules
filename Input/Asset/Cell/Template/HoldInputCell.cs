using GeneralModule.Input.Operator;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using R3;

namespace GeneralModule.Input.Asset.Cell.Template {
    public class HoldInputCell : AInputContextCell {

        [TitleGroup("“ü—Í")]
        [SerializeField]
        [LabelText("’·‰Ÿ‚µ‚·‚éŽžŠÔ(ms)")]
        [ProgressBar(0, 10000)]
        private int m_holdTime = 1000;

        protected override void InputContext() {
            m_primaryInput
                .Hold(TimeSpan.FromMilliseconds(m_holdTime))
                .SelectMany(x => {
                    return Observable
                    .ReturnUnit()
                    .Delay(TimeSpan.FromMilliseconds(m_cancelGrace))
                    .TakeUntil(m_cancelStream);
                });
        }
    }
}