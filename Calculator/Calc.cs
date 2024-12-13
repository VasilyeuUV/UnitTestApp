namespace Calculator
{
    /// <summary>
    /// Реализация простого калькулятора
    /// </summary>
    public class Calc : ICalc
    {

        public decimal Add(decimal a, decimal b) 
            => a + b;

        public decimal Subtract(decimal a, decimal b)
            => a - b;

        public decimal Multiply(decimal a, decimal b)
            => a * b;

        public decimal Divide(decimal a, decimal b)
            => a / b;


        /// <summary>
        /// Решение квадратного уравнения вида ax^2 + bx + c = 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double[] SolveQuadratic(double a, double b, double c)
        {
            double d = (b * b - 4 * a * c);             // дискриминант D = b^2 - 4ac 
            return d == 0
                ? [-b / (2 * a)]
                : [
                    (-b - Math.Sqrt(d)) / (2 * a),      // x1 = (-b - √D) / 2a
                    (-b + Math.Sqrt(d)) / (2 * a),      // x2 = (-b + √D) / 2a
                  ];
        }
    }
}
