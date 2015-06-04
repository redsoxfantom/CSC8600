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
        /// The class under test
        /// </summary>
        private MathOperatorsFactory target;

        /// <summary>
        /// Provides access to target's private methods / fields
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            target = new MathOperatorsFactory();
            po = new PrivateObject(target);
            opMock = new Mock<INaryOperator>();
            operators = new Dictionary<string, INaryOperator>();
            po.SetFieldOrProperty("operators", operators);
        }

        /// <summary>
        /// Test the get operator method when the operator is defined
        /// </summary>
        [TestMethod]
        public void OpFactoryGetExistingOperator()
        {
            operators.Add("+", opMock.Object);

            INaryOperator actual = target.GetOperator("+");

            Assert.AreEqual(opMock.Object, actual);
        }

        /// <summary>
        /// Test the getOperator method when the operator is not defined
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void OpFactoryGetNonExistantOperator()
        {
            INaryOperator op = target.GetOperator("BAD_OP");
        }
    }
}
