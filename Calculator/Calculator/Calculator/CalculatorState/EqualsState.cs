using Calculator.MathOperators;
using System;
using System.Collections.Generic;
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
        /// The result of doing the calculation
        /// </summary>
        private double result;

        /// <summary>
        /// Constructor for Equals State
        /// </summary>
        /// <param name="operatorList">The old state's operators</param>
        /// <param name="operandsList">The old state's operands</param>
        public EqualsState(List<double> operandsList, List<INaryOperator> operatorList) : base(operandsList,operatorList)
        {
            String operands = String.Format("[{0}]", String.Join(",", operandsList));
            String operators = String.Format("[{0}]", String.Join(",", operatorList));

            mLogger.Info(string.Format("In equals state with operators: {0} and operands: {1}", operators, operands));

            CalculateResult();
        }

        /// <summary>
        /// Calculates the result of the operations.
        /// When this method is done, the result is stored in the first index of operandsList, 
        /// the final operand to be evaluated is the only operator in operatorList,
        /// and all the operands (except the first) that were input to the final operator are stored in operandsList.
        /// This is done to allow for the user to press "=" multiple times to redo the operation, and also for multiple operators
        /// EX:
        ///     2 + 2 = 4
        ///     4 is stored in operandsList, "+" is stored in operatorsList, the last 2 is stored in operandsList.
        ///     That was, when the user presses "=" again, the calculation will be:
        ///     4 + 2 = 6
        ///     6 + 2 = 8
        ///     etc...
        /// NOTE: This calculation currently cannot support parenthesis or order of operations!
        /// </summary>
        private void CalculateResult()
        {
            mLogger.Debug("Beginning Calculation...");
            INaryOperator op = null;
            List<double> operands = new List<double>();

            while(OperatorList.Count > 0) // For each operator in the operatorList
            {
                operands.Clear(); // Clear out the operands list between each run

                op = OperatorList[0];       //Get the operator at index 0...
                OperatorList.RemoveAt(0);   //..And delete that operator from the list
                mLogger.Debug(string.Format("Pulled operator {0} from head of OperatorList, which expects {1} arguments", op.ToString(),op.NumOperandsExpected()));

                for (int i = 0; i < op.NumOperandsExpected(); i++) // Now construct the list of operands that will be passed to the operator
                {
                    operands.Add(OperandList[i]);
                }
                OperandList.RemoveRange(0, op.NumOperandsExpected()); // Remove the operands wee are going to process
                String numbers = String.Format("[{0}]", String.Join(",", OperandList));
                String args = String.Format("[{0}]", String.Join(",", operands));
                mLogger.Debug(string.Format("Will use {0} as arguments to operator. Remaining arguments: {1}", args, numbers));

                result = op.PerformOperation(operands.ToArray()); // Perform the calculation on the operands
                mLogger.Debug(string.Format("Intermediate operation performed. Result was {0}", result));

                OperandList.Reverse();  //
                OperandList.Add(result);// Reverse the operand array, add the result of the calculation to the end of the array, and reverse it again.
                OperandList.Reverse();  // (This is the same as adding the result to the front of the array to allow future calculations to use it)
                numbers = String.Format("[{0}]", String.Join(",", OperandList));
                mLogger.Debug(string.Format("Stored intermediate result in OperandList. New OperandList: {0}", numbers));
            }

            //Finished doing the calculation, add the final operator and the list of operands (minus the first one)
            OperatorList.Add(op);
            for(int i = 1; i < operands.Count; i++)
            {
                OperandList.Add(operands[i]);
            }
            String finalNumbers = String.Format("[{0}]", String.Join(",", OperandList));
            String operators = String.Format("[{0}]", String.Join(",", OperatorList));
            mLogger.Debug(string.Format("Finished Calculation. Final Result: {0}. Final OperandList: {1}. Final OperatorList: {2}", result, finalNumbers, operators));
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
                mLogger.Info(string.Format("Attempting Transition from EqualsState to OperandState with op {0}",op));
                newState = new OperandState(new List<double>(), new List<INaryOperator>(), op);
            }
            catch(Exception ex)
            {
                mLogger.Error(string.Format("Error transitioning from EqualsState to OperandState: {0}", ex.Message));
                newState = this;
            }

            return newState;
        }

        /// <summary>
        /// Called when the user enters an operator
        /// </summary>
        /// <param name="op">The entered operator</param>
        /// <returns>The state the state transitions to</returns>
        public override ICalculatorState OperatorTransition(INaryOperator op)
        {
            List<double> newOperands = new List<double>();
            newOperands.Add(result); // Add the result of this calculation to the operandList to allow it to be used in future calculations

            mLogger.Info(string.Format("Attempting transition from EqualsState to OperatorState with operator {0}", op.ToString()));
            ICalculatorState newState = new OperatorState(newOperands, new List<INaryOperator>(), op);

            return newState;
        }

        /// <summary>
        /// Called when the user presses Equals
        /// </summary>
        /// <returns>The state this state transitions to</returns>
        public override ICalculatorState EqualsTransition()
        {
            try
            {
                //Create copies of the lists to send in. Do this in case an exception is thrown and we want to prevent the lists from getting trashed
                List<INaryOperator> newOperatorList = new List<INaryOperator>(OperatorList.ToArray());
                List<double> newOperandList = new List<double>(OperandList.ToArray());
                mLogger.Info("Attempting transition from EqualsState to EqualsState");
                return new EqualsState(newOperandList, newOperatorList);
            }
            catch(Exception ex)
            {
                mLogger.Error(string.Format("Failed to transition from EqualsState to EqualsState: {0}", ex.Message));
                return this;
            }
        }

        /// <summary>
        /// Get the current number the user has entered
        /// </summary>
        /// <returns>The number this state is operating on</returns>
        public override string GetCurrentNumber()
        {
            return result.ToString();
        }
    }
}
