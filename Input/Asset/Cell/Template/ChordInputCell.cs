using GeneralModule.Input.Asset.Cell.Interface;
using GeneralModule.Input.Operator;
using NUnit.Framework;
using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralModule.Input.Asset.Cell.Template {
    public class ChordInputCell : AInputContextCell {

        [TitleGroup("“ü—Í")]
        [OdinSerialize]
        [LabelText("“¯Žž‚É“ü—Í‚·‚éƒ{ƒ^ƒ“")]
        private List<IInputContextCell> m_secondInput = new();

        protected override void InputContext() {

            if (m_secondInput is null || m_secondInput.Count is 0) {
                throw new ArgumentOutOfRangeException();
            }

            var secondStream = m_secondInput.Select(x => x.Signal).ToArray();

            m_primaryInput
                .Chord(secondStream)
                .SelectMany(x => {
                    return Observable
                    .ReturnUnit()
                    .Delay(TimeSpan.FromMilliseconds(m_cancelGrace))
                    .TakeUntil(m_cancelStream);
                });
               
        }
    }
}