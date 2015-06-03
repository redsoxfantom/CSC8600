﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.MathOperators.BinaryOperators
{
    /// <summary>
    /// Binary operator that adds two operands together
    /// </summary>
    public class AdditionOperator : BinaryOperator
    {
        /// <summary>
        /// Add two numbers together, return the result
        /// </summary>
        /// <param name="operand1">The first number</param>
        /// <param name="operand2">The second numbers</param>
        /// <returns>The two numbers added together</returns>
        protected override double PerformOperation(double operand1, double operand2)
        {
            double result = operand1 + operand2;

            return result;
        }
    }
}
