using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators.MathOperatorsFactory
{
    /// <summary>
    /// Interface for the MathOperatorsFactory
    /// </summary>
    public interface IMathOperatorsFactory
    {
        /// <summary>
        /// Given an operator's symbol, return an instance of the INaryOperator represented by that symbol
        /// </summary>
        /// <param name="symbol">The symbol associated with an operator (ex: + => AdditionOperator)</param>
        /// <returns>The N-Ary operator</returns>
        INaryOperator GetOperator(string symbol);

        /// <summary>
        /// Read in the config file defining the list of operators to support
        /// </summary>
        void InitializeOperators();
    }
}
