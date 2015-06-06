using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    public abstract class BaseCalculatorState : ICalculatorState
    {
        /// <summary>
        /// List of entered Operands
        /// </summary>
        protected List<double> OperandList;

        /// <summary>
        /// List of entered Operators
        /// </summary>
        protected List<INaryOperator> OperatorList;

        /// <summary>
        /// Publically accessible Constructor
        /// </summary>
        public BaseCalculatorState()
        {
            OperandList = new List<double>();
            OperatorList = new List<INaryOperator>();
        }

        /// <summary>
        /// Constructor called when transitioning to a new state
        /// </summary>
        /// <param name="operandList">The old state's operands</param>
        /// <param name="operatorList">The old state's operators</param>
        public BaseCalculatorState(List<double> operandList, List<INaryOperator> operatorList)
        {
            OperatorList = operatorList;
            OperandList = operandList;
        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public abstract ICalculatorState OperandTransition(string op);

        /// <summary>
        /// Called when the user enters an operator
        /// </summary>
        /// <param name="op">The entered operator</param>
        /// <returns>The state the state transitions to</returns>
        public abstract ICalculatorState OperatorTransition(INaryOperator op);

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        public abstract ICalculatorState EqualsTransition();

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        public abstract string GetCurrentNumber();
    }
}
