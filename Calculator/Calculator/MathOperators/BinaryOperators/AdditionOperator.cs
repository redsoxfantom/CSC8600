using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators.BinaryOperators
{
    /// <summary>
    /// Binary operator that adds two operands together
    /// </summary>
    public class AdditionOperator : INaryOperator
    {
        /// <summary>
        /// Adds two numbers together
        /// </summary>
        /// <param name="operands">A list of operands. Must equal 2</param>
        /// <returns>The two operands added together</returns>
        public double PerformOperation(params double[] operands)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This operator requires two operands
        /// </summary>
        /// <returns>2</returns>
        public int NumOperandsExpected()
        {
            return 2;
        }
    }
}
