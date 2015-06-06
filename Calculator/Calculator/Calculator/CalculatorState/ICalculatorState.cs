using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    /// <summary>
    /// Interface for all states a calculator server can get in
    /// </summary>
    public interface ICalculatorState
    {
        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        ICalculatorState OperandTransition(string op);

        /// <summary>
        /// Called when the user enters an operator
        /// </summary>
        /// <param name="op">The entered operator</param>
        /// <returns>The state the state transitions to</returns>
        ICalculatorState OperatorTransition(INaryOperator op);

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        ICalculatorState EqualsTransition();

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        string GetCurrentNumber();
    }
}
