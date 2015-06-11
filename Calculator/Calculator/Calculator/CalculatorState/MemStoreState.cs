using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.CalculatorState
{
    /// <summary>
    /// State the calculator enters when the user presses MemStore
    /// </summary>
    public class MemStoreState : BaseCalculatorState
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="operandList">operand list</param>
        /// <param name="operatorList">operator list</param>
        /// <param name="valueToStore">The value to store in memory</param>
        public MemStoreState(List<double> operandList, List<INaryOperator> operatorList, string valueToStore) : base (operandList,operatorList)
        {
            mLogger.Info(string.Format("In MemStoreState with valueToStore: {0}", valueToStore));
            CalculatorMemory.StoredValue = valueToStore;
        }

        /// <summary>
        /// Called when the user enters a number / decimal point
        /// </summary>
        /// <param name="op">The entered operand</param>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState OperandTransition(string op)
        {
            string newOperand = CalculatorMemory.StoredValue + op;
            try
            {
                mLogger.Info(string.Format("Attempting to transition from MemStoreState to OperandState with op [{0}]",newOperand));
                return new OperandState(OperandList, OperatorList, newOperand);
            }
            catch(Exception ex)
            {
                mLogger.Error(string.Format("Failed to transition to OperandState: {0}", ex.Message));
                return this;
            }
        }

        /// <summary>
        /// Called when the user enters an operator
        /// </summary>
        /// <param name="op">The entered operator</param>
        /// <returns>The state the state transitions to</returns>
        public override ICalculatorState OperatorTransition(MathOperators.INaryOperator op)
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
            return CalculatorMemory.StoredValue;
        }
    }
}
