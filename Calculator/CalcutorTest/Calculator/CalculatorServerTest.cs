using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator;
using Moq;
using Calculator.MathOperators.MathOperatorsFactory;
using Calculator.MathOperators;

namespace CalcutorTest.Calculator
{
    /// <summary>
    /// Test of the Calculator class
    /// </summary>
    [TestClass]
    public class CalculatorServerTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private CalculatorServer target;

        /// <summary>
        /// Provides access to target's private methods / fields
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// A mocked out Math operators factory
        /// </summary>
        private Mock<IMathOperatorsFactory> mockFactory;

        /// <summary>
        /// A mocked out operator
        /// </summary>
        private Mock<INaryOperator> mockOp;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            target = new CalculatorServer();
            po = new PrivateObject(target);
            mockFactory = new Mock<IMathOperatorsFactory>();
            mockOp = new Mock<INaryOperator>();

            po.SetFieldOrProperty("opFactory", mockFactory.Object);
            mockFactory.Setup(f => f.GetOperator("Good Op")).Returns(mockOp.Object);
            mockFactory.Setup(f => f.GetOperator("Bad Op")).Throws(new MathOperatorException());
        }

        /// <summary>
        /// Test the Initialize method
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestInitialize()
        {
            target.Initialize();

            mockFactory.Verify(f => f.InitializeOperators(), Times.Once());
        }
    }
}
