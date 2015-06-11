using Calculator.Calculator.CalculatorState;
using Calculator.Logger;
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
    /// Delegate called when the calculator server's number is updated
    /// </summary>
    /// <param name="newNum">The new number from the server</param>
    public delegate void NumberUpdated(String newNum);

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
        /// Event for clients to register for to see the new number from this server
        /// </summary>
        public event NumberUpdated Updated;

        /// <summary>
        /// Logger for the server
        /// </summary>
        private ILogger mLogger;

        /// <summary>
        /// The constructor
        /// </summary>
        public CalculatorServer()
        {
            opFactory = new MathOperatorsFactory();
            mState = new InitialState();
            mLogger = LoggerFactory.CreateLogger(this.GetType().Name);
        }

        /// <summary>
        /// Initialize the Calculator
        /// </summary>
        public void Initialize()
        {
            opFactory.InitializeOperators();
            OnUpdated();
        }

        /// <summary>
        /// Called when the user presses a number on the calculator GUI
        /// </summary>
        /// <param name="number">The number the user entered</param>
        public void AcceptNumber(string number)
        {
            try
            {
                mState = mState.OperandTransition(number);
            }
            catch(Exception ex)
            {
                OnTransitionError(ex);
            }
            OnUpdated();
        }

        /// <summary>
        /// Called when the user presses an operator key
        /// </summary>
        /// <param name="op">The operator</param>
        public void AcceptOperator(string op)
        {
            INaryOperator newOp = opFactory.GetOperator(op);
            try
            {
                mState = mState.OperatorTransition(newOp);
            }
            catch(Exception ex)
            {
                OnTransitionError(ex);
            }
            OnUpdated();
        }

        /// <summary>
        /// Called when the user presses the Equals key
        /// </summary>
        public void AcceptEquals()
        {
            try
            {
                mState = mState.EqualsTransition();
            }
            catch (Exception ex)
            {
                OnTransitionError(ex);
            }
            OnUpdated();
        }

        /// <summary>
        /// Called when a state transition throws an uncaught error
        /// </summary>
        private void OnTransitionError(Exception ex)
        {
            mLogger.Error(string.Format("Calculator server caught error [{0}]. Calculator state will be reset"));
            mState = new InitialState();
            OnUpdated();
        }

        /// <summary>
        /// Update all clients that a new number is available
        /// </summary>
        private void OnUpdated()
        {
            if(Updated != null)
            {
                Updated(mState.GetCurrentNumber());
            }
        }
    }
}
