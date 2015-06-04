using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.MathOperators;
using System.Collections.Generic;
using System.Reflection;
using Moq;

namespace CalculatorTest.MathOperators
{
    /// <summary>
    /// Test of the MathOperators factory class
    /// </summary>
    [TestClass]
    public class MathOperatorsTest
    {
        /// <summary>
        /// The target's operators
        /// </summary>
        private Dictionary<string, INaryOperator> operators;

        /// <summary>
        /// A mocked out operator
        /// </summary>
        private Mock<INaryOperator> opMock;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            opMock = new Mock<INaryOperator>();
            operators = new Dictionary<string, INaryOperator>();
            FieldInfo operatorsField = typeof(MathOperatorsFactory).GetField("operators", BindingFlags.NonPublic | BindingFlags.Static);
            operatorsField.SetValue(null, operators);
        }

        /// <summary>
        /// Test the get operator method when the operator is defined
        /// </summary>
        [TestMethod]
        public void OpFactoryGetExistingOperator()
        {
            operators.Add("+", opMock.Object);

            INaryOperator actual = MathOperatorsFactory.GetOperator("+");

            Assert.AreEqual(opMock.Object, actual);
        }

        /// <summary>
        /// Test the getOperator method when the operator is not defined
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void OpFactoryGetNonExistantOperator()
        {
            INaryOperator op = MathOperatorsFactory.GetOperator("BAD_OP");
        }
    }
}
