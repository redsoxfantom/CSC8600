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
    public class CalculatorServer : ICalculator
    {
        /// <summary>
        /// A list of all numbers the user entered before pressing the equals sign
        /// </summary>
        private List<double> previouslyEnteredNumbers;

        /// <summary>
        /// The number displayed on the screen
        /// </summary>
        private double mDisplayedNumber;

        /// <summary>
        /// The factory that generates math operators
        /// </summary>
        private IMathOperatorsFactory opFactory;

        /// <summary>
        /// The operator the user selected
        /// </summary>
        private INaryOperator currentOperator;

        /// <summary>
        /// The constructor
        /// </summary>
        public CalculatorServer()
        {
            mDisplayedNumber = 0;
            previouslyEnteredNumbers = new List<double>();
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
            StringBuilder currentNumberString = new StringBuilder(mDisplayedNumber.ToString());
            currentNumberString.Append(number);

            if(!Double.TryParse(currentNumberString.ToString(), out mDisplayedNumber))
            {
                mDisplayedNumber = 0;
                throw new CalculatorException(string.Format("The entered number {0} is not valid",currentNumberString.ToString()));
            }
        }

        /// <summary>
        /// Called when the user presses an operator key
        /// </summary>
        /// <param name="op">The operator</param>
        public void AcceptOperator(string op)
        {
            currentOperator = opFactory.GetOperator(op);
            previouslyEnteredNumbers.Add(mDisplayedNumber);
            mDisplayedNumber = 0;
        }

        /// <summary>
        /// Called when the user presses the Equals key
        /// </summary>
        public void AcceptEquals()
        {

        }
    }
}
