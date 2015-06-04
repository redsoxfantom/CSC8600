using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators
{
    /// <summary>
    /// Factory class that returns a math operator given that operator's symbol.
    /// </summary>
    public class MathOperatorsFactory
    {
        /// <summary>
        /// Stores the list of operators and their symbols
        /// </summary>
        private static Dictionary<string, INaryOperator> operators = new Dictionary<string, INaryOperator>();

        /// <summary>
        /// Given an operator's symbol, return an instance of the INaryOperator represented by that symbol
        /// </summary>
        /// <param name="symbol">The symbol associated with an operator (ex: + => AdditionOperator)</param>
        /// <returns>The N-Ary operator</returns>
        public static INaryOperator GetOperator(string symbol)
        {
            if(operators.ContainsKey(symbol))
            {
                return operators[symbol];
            }
            else
            {
                throw new MathOperatorException(string.Format("Math symbol {0} not defined", symbol));
            }
        }
    }
}
