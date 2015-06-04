using Calculator.MathOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    /// <summary>
    /// Interface for the Calculator class
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Called when the user presses a number on the calculator GUI
        /// </summary>
        /// <param name="number">The number the user entered</param>
        void AcceptNumber(string number);

        /// <summary>
        /// Called when the user presses an operator key
        /// </summary>
        /// <param name="op">The operator</param>
        void AcceptOperator(string op);

        /// <summary>
        /// Called when the user pressed the "=" key
        /// </summary>
        void AcceptEquals();
        
        /// <summary>
        /// Initialize the Calculator
        /// </summary>
        void Initialize();
    }
}
