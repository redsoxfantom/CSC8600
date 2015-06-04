using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Implements the Calculator functionality
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// The number the user entered
        /// </summary>
        private double mEnteredNumber;

        /// <summary>
        /// The constructor
        /// </summary>
        public Calculator()
        {
            mEnteredNumber = 0;
        }

        /// <summary>
        /// Called when the user presses a number on the calculator GUI
        /// </summary>
        /// <param name="number">The number the user entered</param>
        public void AcceptNumber(string number)
        {
            StringBuilder currentNumberString = new StringBuilder(mEnteredNumber.ToString());
            currentNumberString.Append(number);

            if(!Double.TryParse(currentNumberString.ToString(), out mEnteredNumber))
            {

            }
        }

        /// <summary>
        /// Called when the user presses an operator key
        /// </summary>
        /// <param name="op">The operator</param>
        public void AcceptOperator(INaryOperator op)
        {

        }
    }
}
