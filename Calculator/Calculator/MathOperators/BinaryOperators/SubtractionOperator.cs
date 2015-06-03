using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators.BinaryOperators
{
    /// <summary>
    /// Subtracts two numbers
    /// </summary>
    public class SubtractionOperator : BinaryOperator
    {
        /// <summary>
        /// Subtract two numbers
        /// </summary>
        /// <param name="operand1">The first number</param>
        /// <param name="operand2">The second number</param>
        /// <returns>The result</returns>
        protected override double PerformOperation(double operand1, double operand2)
        {
            double result = operand1 - operand2;

            return result;
        }
    }
}
