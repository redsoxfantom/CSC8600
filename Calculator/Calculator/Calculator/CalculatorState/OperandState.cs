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
        /// Stores whether the last operand a user entered was a decimal.
        /// This is needed because C# canot parse a double ending in ".", so we will
        /// need to append a "0" on the end (making it ".0"). However, we need to remember that
        /// we did this so we can remove it when transitioning to the Operand state
        /// </summary>
        private bool mWasLastOperandADecimal;

        /// <summary>
        /// Construct the state
        /// </summary>
        /// <param name="operandList">The previous operands</param>
        /// <param name="operatorList">The previous operators</param>
        /// <param name="initialNumber">The initial operand of this state</param>
        public OperandState(List<double> operandList, List<INaryOperator> operatorList, string initialOperand) : base(operandList,operatorList)
        {
            mLogger.Info(string.Format("In Operand State, intial operand: [{0}]", initialOperand));

            // Check if the input string ends in a .
            if(initialOperand[initialOperand.Length-1] == '.')
            {
                // If it does, append a '0'
                initialOperand = initialOperand + "0";
                mWasLastOperandADecimal = true;
                mLogger.Debug("Initial Operand ends with a decimal");
            }
            else
            {
                mWasLastOperandADecimal = false;
            }

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
            string mCurrentNumberString = mCurrentNumber.ToString();

            // If we added a "0" to this number to get it to parse,
            // then we need to manually add the decimal back into the string
            // and then add the "op"
            if(mWasLastOperandADecimal)
            {
                mCurrentNumberString += "."; 
            }
            mCurrentNumberString += op;
            
            try
            {
                mLogger.Info("Attempting to transition from OperandState to OperandState");
                ICalculatorState newState = new OperandState(OperandList, OperatorList, mCurrentNumberString);
                return newState;
            }
            catch(Exception ex)
            {
                // If an exception occurs, log it and return the current state
                mLogger.Error(string.Format("Could not transition from OperandState to OperandState: {0}", ex.Message));
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
            mLogger.Info(string.Format("Transitioning from Operand State to Operator State, final Operand was [{0}]",mCurrentNumber.ToString()));

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
                OperandList.Add(mCurrentNumber);
                mLogger.Info(string.Format("Attempting to transition from Operand State to Equals State, final Operand was [{0}]", mCurrentNumber.ToString()));
                return new EqualsState(OperandList, OperatorList);
            }
            catch(Exception ex)
            {
                mLogger.Error(string.Format("Failed to transition to EqualsState from OperandState: {0}", ex.Message));
                OperandList.RemoveAt(OperandList.Count - 1); // Remove the last element in the list (the element we just added)
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
