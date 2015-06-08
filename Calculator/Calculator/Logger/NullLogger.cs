using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Logger
{
    /// <summary>
    /// A logger that does nothing
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// The constructor
        /// </summary>
        public NullLogger()
        {

        }

        /// <summary>
        /// Prints a debug string
        /// </summary>
        /// <param name="str">The string</param>
        public void Debug(string str)
        {
            //Do nothing
        }

        /// <summary>
        /// Prints an info string
        /// </summary>
        /// <param name="str">The string</param>
        public void Info(string str)
        {
            //Do nothing
        }

        /// <summary>
        /// Prints an error string
        /// </summary>
        /// <param name="str">str</param>
        public void Error(string str)
        {
            //Do nothing
        }
    }
}
