using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    /// <summary>
    /// State entered when the user presses "="
    /// </summary>
    public class EqualsState : BaseCalculatorState
    {
        /// <summary>
        /// Constructor for Equals State
        /// </summary>
        /// <param name="operatorList">The old state's operators</param>
        /// <param name="operandsList">The old state's operands</param>
        public EqualsState(List<double> operandsList, List<INaryOperator> operatorList) : base(operandsList,operatorList)
        {
            // TODO: Calculate the result here
        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState OperandTransition(string op)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the user enters an operator
        /// </summary>
        /// <param name="op">The entered operator</param>
        /// <returns>The state the state transitions to</returns>
        public override ICalculatorState OperatorTransition(INaryOperator op)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState EqualsTransition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        public override string GetCurrentNumber()
        {
            throw new NotImplementedException();
        }
    }
}
