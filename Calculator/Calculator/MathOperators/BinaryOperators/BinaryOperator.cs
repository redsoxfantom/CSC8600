using Calculator.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators.BinaryOperators
{
    /// <summary>
    /// Base class for all binary operators (operators taking exactly two arguments)
    /// </summary>
    public abstract class BinaryOperator : INaryOperator
    {
        /// <summary>
        /// The logger for the Operator
        /// </summary>
        protected ILogger mLogger;

        /// <summary>
        /// Constructor for the operator
        /// </summary>
        public BinaryOperator()
        {
            mLogger = LoggerFactory.CreateLogger(this.GetType().Name);
        }

        /// <summary>
        /// Perform the operator's function
        /// </summary>
        /// <param name="operands">a list of exactly two doubles</param>
        /// <returns>the result of the operation</returns>
        public double PerformOperation(params double[] operands)
        {
            if (operands.Length != 2)
            {
                string className = this.GetType().Name;
                throw new MathOperatorException(string.Format("{0} must be given exactly two arguments",className));
            }

            double operand1 = operands[0];
            double operand2 = operands[1];

            return PerformOperation(operand1, operand2);
        }

        /// <summary>
        /// Returns the number of operands expected (2)
        /// </summary>
        /// <returns>2</returns>
        public int NumOperandsExpected()
        {
            return 2;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>The operator's symbol</returns>
        public abstract override string ToString();

        /// <summary>
        /// Perform the actual function of the operator
        /// </summary>
        /// <param name="operand1">The first operand</param>
        /// <param name="operand2">The second operand</param>
        /// <returns>The result of the operation</returns>
        protected abstract double PerformOperation(double operand1, double operand2);
    }
}
