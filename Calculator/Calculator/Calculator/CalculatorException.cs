using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    /// <summary>
    /// Exception thrown by the Calculator class
    /// </summary>
    public class CalculatorException : Exception
    {
        /// <summary>
        /// Create an exception with an error message
        /// </summary>
        /// <param name="err">The error message</param>
        public CalculatorException(string err) : base (err)
        {

        }
    }
}
