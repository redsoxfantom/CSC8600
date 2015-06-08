using Calculator.Calculator.CalculatorState;
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
    public class CalculatorServer : ICalculatorServer
    {
        /// <summary>
        /// The factory that generates math operators
        /// </summary>
        private IMathOperatorsFactory opFactory;

        /// <summary>
        /// The current state of the calculator
        /// </summary>
        private ICalculatorState mState;

        /// <summary>
        /// The constructor
        /// </summary>
        public CalculatorServer()
        {
            opFactory = new MathOperatorsFactory();
            mState = new InitialState();
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
            mState = mState.OperandTransition(number);
        }

        /// <summary>
        /// Called when the user presses an operator key
        /// </summary>
        /// <param name="op">The operator</param>
        public void AcceptOperator(string op)
        {
            INaryOperator newOp = opFactory.GetOperator(op);
            mState = mState.OperatorTransition(newOp);
        }

        /// <summary>
        /// Called when the user presses the Equals key
        /// </summary>
        public void AcceptEquals()
        {
            mState = mState.EqualsTransition();
        }
    }
}
