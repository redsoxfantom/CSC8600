using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator;
using Moq;
using Calculator.MathOperators.MathOperatorsFactory;
using Calculator.MathOperators;
using System.Collections.Generic;
using Calculator.Calculator.CalculatorState;

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
        /// The mocked out state of the calculator
        /// </summary>
        private Mock<ICalculatorState> mockState;

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
            mockState = new Mock<ICalculatorState>();
            mockOp = new Mock<INaryOperator>();

            po.SetFieldOrProperty("mState", mockState.Object);
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

        /// <summary>
        /// Test the Accept Number method
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestNumber()
        {
            target.AcceptNumber("1");

            mockState.Verify(f => f.OperandTransition("1"), Times.Once());
        }

        /// <summary>
        /// Test the AcceptOperator method
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestOperatorGood()
        {
            target.AcceptOperator("Good Op");

            mockFactory.Verify(f => f.GetOperator("Good Op"), Times.Once());
            mockState.Verify(f => f.OperatorTransition(mockOp.Object), Times.Once());
        }

        /// <summary>
        /// Test the AcceptOperator method when given bad input
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void CalculatorServerTestOperatorBad()
        {
            target.AcceptOperator("Bad Op");
        }

        /// <summary>
        /// Test the AcceptEquals method
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestEqualsNullOperator()
        {
            target.AcceptEquals();

            mockState.Verify(f => f.EqualsTransition(), Times.Once());
        }
    }
}
