using System.Linq;
using GeneralModule.Calculator.Interface;

namespace GeneralModule.Calculator {
    public class FloatCalculator : ICalculator<float> {
        
        public float Add(float a, float b) => a + b;

        public float Add(float[] values) => values.Sum();
        
        public float Subtract(float a, float b) => a - b;

        public float Subtract(float[] values) => values.Sum() * Minus;
        
        public float Multiply(float a, float b) => a * b;

        public float Multiply(float[] values) {
            float result = values[0];
            for (int i = 1; i < values.Length; i++) {
                result *= values[i];
            }
            return result;
        }
        
        public float Divide(float a, float b) => a / b;
        
        public bool Equal (float a, float b) => a == b;
        
        public bool Greater (float a, float b) => a > b;
        
        public bool Less (float a, float b) => a < b;

        public float Zero => 0.0f;

        public float Minus => -1.0f;
    }
}