using System.Linq;
using GeneralModule.Calculator.Interface;
using Sirenix.Utilities;

namespace GeneralModule.Calculator {
    /// <summary>
    /// int型の計算に用いる糖衣構文クラス
    /// </summary>
    public class IntCalculator : ICalculator<int> {
        
        public int Add(int a, int b) => a + b;
        
        public int Add (int[] values) => values.Sum();
        
        public int Subtract(int a, int b) => a - b;

        public int Subtract(int[] values) => values.Sum() * -1;
        
        public int Multiply(int a, int b) => a * b;

        public int Multiply(int[] values) {
            var result = values[0];
            for (int i = 1; i < values.Length; i++) {
                result *= values[i];
            }
            return result;
        }
        
        public int Divide(int a, int b) => a / b;

        public bool Equal(int a, int b) => a == b;
        
        public bool Greater (int a, int b) => a > b;
        
        public bool Less (int a, int b) => a < b;

        public int Zero => 0;

        public int Minus => -1;
    }
}