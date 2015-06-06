using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    public class OperandState : BaseCalculatorState
    {
        /// <summary>
        /// Stores the number the user is creating
        /// </summary>
        private double mCurrentNumber;

        /// <summary>
        /// Construct the state
        /// </summary>
        /// <param name="operandList">The previous operands</param>
        /// <param name="operatorList">The previous operators</param>
        /// <param name="initialNumber">The initial operand of this state</param>
        public OperandState(List<double> operandList, List<INaryOperator> operatorList, string initialOperand) : base(operandList,operatorList)
        {
            if(!double.TryParse(initialOperand,out mCurrentNumber))
            {
                throw new CalculatorException(string.Format("Entered operand \"{0}\" is not a legal operand",initialOperand));
            }
        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState OperandTransition(string op)
        {
            return null;
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
