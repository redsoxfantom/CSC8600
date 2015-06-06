using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    /// <summary>
    /// State the calculator enters when the user presses a number or decimal
    /// </summary>
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
        /// Construct the state with an implied initial operand of 0
        /// </summary>
        /// <param name="operandList">The old state's operand list</param>
        /// <param name="operatorList">The old state's operator list</param>
        public OperandState(List<double> operandList, List<INaryOperator> operatorList) : this(operandList,operatorList,"0")
        {

        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState OperandTransition(string op)
        {
            string mCurrentNumberString = mCurrentNumber.ToString() + op;
            try
            {
                ICalculatorState newState = new OperandState(OperandList, OperatorList, mCurrentNumberString);
                return newState;
            }
            catch(Exception ex)
            {
                // If an exception occurs, log it and return the current state
                Console.WriteLine(string.Format("Could not transition from OperandState to OperandState: {0}", ex.Message));
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
            OperandList.Add(mCurrentNumber);

            return new OperatorState(OperandList, OperatorList, op);
        }

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState EqualsTransition()
        {
            try
            {
                return new EqualsState(OperandList, OperatorList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Failed to transition to EqualsState from OperandState: {0}", ex.Message));
                return this;
            }
        }

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        public override string GetCurrentNumber()
        {
            return mCurrentNumber.ToString();
        }
    }
}
