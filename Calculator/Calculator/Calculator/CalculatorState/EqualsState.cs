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
            INaryOperator op = null;
            List<double> operands = new List<double>();

            while(OperatorList.Count > 0) // For each operator in the operatorList
            {
                op = OperatorList[0];       //Get the operator at index 0...
                OperatorList.RemoveAt(0);   //..And delete that operator from the list

                for (int i = 0; i < op.NumOperandsExpected(); i++) // Now construct the list of operands that will be passed to the operator
                {
                    operands.Add(OperandList[i]);
                }
                OperandList.RemoveRange(0, op.NumOperandsExpected()); // Remove the operands wee are going to process

                result = op.PerformOperation(operands.ToArray()); // Perform the calculation on the operands

                OperandList.Reverse();  //
                OperandList.Add(result);// Reverse the operand array, add the result of the calculation to the end of the array, and reverse it again.
                OperandList.Reverse();  // (This is the same as adding the result to the front of the array to allow future calculations to use it)
            }

            //Finished doing the calculation, add the final operator and the list of operands (minus the first one)
            OperatorList.Add(op);
            for(int i = 1; i < operands.Count; i++)
            {
                OperandList.Add(operands[i]);
            }
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
                newState = new OperandState(new List<double>(), new List<INaryOperator>(), op);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Error transitioning from EqualsState to OperandState: {0}", ex.Message));
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
                return new EqualsState(OperandList, OperatorList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("Failed to transition from EqualsState to EqualsState: {0}", ex.Message));
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
