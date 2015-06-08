using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Logger
{
    /// <summary>
    /// Interface for Loggers
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Prints a debug string
        /// </summary>
        /// <param name="str">The string</param>
        void Debug(string str);

        /// <summary>
        /// Prints an info string
        /// </summary>
        /// <param name="str">The string</param>
        void Info(string str);

        /// <summary>
        /// Prints an error string
        /// </summary>
        /// <param name="str">str</param>
        void Error(string str);
    }
}
