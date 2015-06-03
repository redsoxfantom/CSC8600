using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators
{
    /// <summary>
    /// Exception thrown by all math operators
    /// </summary>
    public class MathOperatorException : Exception
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        public MathOperatorException() 
            : base()
        { }

        /// <summary>
        /// Constructor taking an error string
        /// </summary>
        /// <param name="err">the error string</param>
        public MathOperatorException(string err)
            : base(err)
        { }
    }
}
