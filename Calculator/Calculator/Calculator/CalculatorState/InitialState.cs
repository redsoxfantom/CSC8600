using Calculator.MathOperators;
using System;

namespace Calculator.Calculator.CalculatorState
{
    /// <summary>
    /// Initial state the calculator server is in
    /// </summary>
    public class InitialState : BaseCalculatorState
    {
        /// <summary>
        /// Initialize the state
        /// </summary>
        public InitialState() : base()
        {

        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState OperandTransition(string op)
        {
            ICalculatorState newState;
            try
            {
                newState = new OperandState(OperandList, OperatorList, op);
                return newState;
            }
            catch(CalculatorException ex)
            {
                //If there is an error transitioning, log it and stay in this state
                Console.WriteLine(string.Format("Error transitioning from InitialState to OperandState: {0}",ex.Message));
                return this;
            }
        }

        /// <summary>
        /// Called when the user enters an operator
        /// </summary>
        /// <param name="op">The entered operator</param>
        /// <returns>The state the state transitions to</returns>
        public override ICalculatorState OperatorTransition(INaryOperator op)
        {
            // Don't transition when user presses an operator
            return this;
        }

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState EqualsTransition()
        {
            // Don't transition on equals
            return this;
        }

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        public override string GetCurrentNumber()
        {
            return "";
        }
    }
}
