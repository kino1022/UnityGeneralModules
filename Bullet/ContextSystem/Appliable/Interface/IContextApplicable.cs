using System.Collections.Generic;
using GeneralModule.Bullet.ContextSystem.Context.Interface;

namespace GeneralModule.Bullet.ContextSystem.Appliable.Interface {
    /// <summary>
    /// IContextの修飾を適用できるクラスに対して約束するインターフェース
    /// </summary>
    public interface IContextApplicable {
        /// <summary>
        /// IContextのリストを受け取りその中から適用できるIContextを適用する
        /// </summary>
        /// <param name="contexts"></param>
        /// <returns></returns>
        bool Apply (List<IContext> contexts);
    }
}