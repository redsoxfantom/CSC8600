using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators.BinaryOperators
{
    /// <summary>
    /// Multiplies two numbers together
    /// </summary>
    public class MultiplicationOperator : BinaryOperator
    {
        /// <summary>
        /// Multiply two numbers
        /// </summary>
        /// <param name="operand1">The first number</param>
        /// <param name="operand2">The second number</param>
        /// <returns>The result</returns>
        protected override double PerformOperation(double operand1, double operand2)
        {
            double result = operand1 * operand2;

            return result;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>*</returns>
        public override string ToString()
        {
            return "*";
        }
    }
}
