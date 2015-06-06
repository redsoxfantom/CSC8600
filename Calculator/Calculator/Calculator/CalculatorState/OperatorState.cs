using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    /// <summary>
    /// State the calculator enters when the user presses an operator key
    /// </summary>
    public class OperatorState : BaseCalculatorState
    {
        /// <summary>
        /// The operator represented by this state
        /// </summary>
        private INaryOperator mOp;

        /// <summary>
        /// Constructor for the State
        /// </summary>
        /// <param name="operatorList">The old state's operators</param>
        /// <param name="operandList">The old state's operands</param>
        /// <param name="op">The operator being applied</param>
        public OperatorState(List<double> operandList, List<INaryOperator> operatorList, INaryOperator op) : base(operandList,operatorList)
        {
            // Just store the operator off for now. Don't enqueue the operator until we transition to another state
            // This is done in case the user enters multiple operators, we only want to save the last one
            mOp = op;
        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState OperandTransition(string op)
        {
            // Now we can store off the operator we were constructed with
            OperatorList.Add(mOp);

            try
            {
                return new OperandState(OperandList, OperatorList, op);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Failed to transition from OperatorState to OperandState: {0}", ex.Message));
                OperatorList.Remove(mOp);
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
            // clear out the old operator by constructing a new one
            return new OperatorState(OperandList, OperatorList, op);
        }

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState EqualsTransition()
        {
            //Save off the operator we were initialized with
            OperatorList.Add(mOp);

            try
            {
                return new EqualsState(OperandList, OperatorList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Failed to transition from OperatorState to EqualsState: {0}", ex.Message));
                OperatorList.Remove(mOp);
                return this;
            }

        }

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        public override string GetCurrentNumber()
        {
            double mCurrentNumber = OperandList[OperandList.Count-1];
            return mCurrentNumber.ToString();
        }
    }
}
