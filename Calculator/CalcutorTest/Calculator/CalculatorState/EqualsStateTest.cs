using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator.CalculatorState;
using System.Collections.Generic;
using Calculator.MathOperators;
using Moq;

namespace CalcutorTest.Calculator.CalculatorState
{
    /// <summary>
    /// Test of the Equals State class
    /// </summary>
    [TestClass]
    public class EqualsStateTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private EqualsState target;

        /// <summary>
        /// Provides access to private methods and fields
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// List of operators
        /// </summary>
        private List<INaryOperator> operatorsList;

        /// <summary>
        /// List of operands
        /// </summary>
        private List<double> operandsList;

        /// <summary>
        /// A mocked out operator
        /// </summary>
        private Mock<INaryOperator> op;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            operandsList = new List<double>();
            operatorsList = new List<INaryOperator>();
            op = new Mock<INaryOperator>();

            target = new EqualsState(operandsList, operatorsList);
            po = new PrivateObject(target);
        }
    }
}
