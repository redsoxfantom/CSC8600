using Calculator.MathOperators;
using Calculator.MathOperators.MathOperatorsFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    /// <summary>
    /// Implements the Calculator functionality
    /// </summary>
    public class Calculator : ICalculator
    {
        /// <summary>
        /// The number the user entered
        /// </summary>
        private double mEnteredNumber;

        /// <summary>
        /// The factory that generates math operators
        /// </summary>
        private IMathOperatorsFactory opFactory;

        /// <summary>
        /// The constructor
        /// </summary>
        public Calculator()
        {
            mEnteredNumber = 0;
            opFactory = new MathOperatorsFactory();
        }

        /// <summary>
        /// Initialize the Calculator
        /// </summary>
        public void Initialize()
        {
            opFactory.InitializeOperators();
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
                mEnteredNumber = 0;
                throw new CalculatorException(string.Format("The entered number {0} is not valid",currentNumberString.ToString()));
            }
        }

        /// <summary>
        /// Called when the user presses an operator key
        /// </summary>
        /// <param name="op">The operator</param>
        public void AcceptOperator(string op)
        {

        }
    }
}
