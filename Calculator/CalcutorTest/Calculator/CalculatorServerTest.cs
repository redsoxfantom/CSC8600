using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator;
using Moq;
using Calculator.MathOperators.MathOperatorsFactory;
using Calculator.MathOperators;
using System.Collections.Generic;

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
        /// The list of numbers entered by the user
        /// </summary>
        private List<double> previouslyEnteredNumbers;

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

            previouslyEnteredNumbers = (List<double>)po.GetFieldOrProperty("previouslyEnteredNumbers");
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
        /// Test the Accept Number when given invalid input
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CalculatorException))]
        public void CalculatorServerTestNumberBadChar()
        {
            target.AcceptNumber("a");
        }

        /// <summary>
        /// Test the Accept Number method when given good input
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestNumberGoodNumber()
        {
            target.AcceptNumber("1");

            double actual = (double)po.GetFieldOrProperty("mDisplayedNumber");
            double expected = 1;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the Accept Number method when given multiple good input
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestNumberMultipleGood()
        {
            target.AcceptNumber("1");
            target.AcceptNumber("2");
            target.AcceptNumber("3");

            double actual = (double)po.GetFieldOrProperty("mDisplayedNumber");
            double expected = 123;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the Accept Number method when the resulting double would be more than the max possible
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CalculatorException))]
        public void CalculatorServerTestNumberBadMax()
        {
            double num = double.MaxValue;
            po.SetFieldOrProperty("mDisplayedNumber", num);

            target.AcceptNumber("1");
        }

        /// <summary>
        /// Test the AcceptOperator method when given good input
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestOperatorGood()
        {
            po.SetFieldOrProperty("mDisplayedNumber", 1234);

            target.AcceptOperator("Good Op");

            mockFactory.Verify(f => f.GetOperator("Good Op"), Times.Once());
            INaryOperator actual = (INaryOperator)po.GetFieldOrProperty("currentOperator");
            Assert.AreEqual(mockOp.Object, actual);
            Assert.AreEqual(1, previouslyEnteredNumbers.Count);
            Assert.AreEqual(1234, previouslyEnteredNumbers[0]);
            double mEnteredNumber = (double)po.GetFieldOrProperty("mDisplayedNumber");
            Assert.AreEqual(0, mEnteredNumber);
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
        /// Test the AcceptEquals method when there is no operator defined
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CalculatorException))]
        public void CalculatorServerTestEqualsNullOperator()
        {
            target.AcceptEquals();
        }

        /// <summary>
        /// Successful test of AcceptEquals given no previous inputs
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestEqualsGood()
        {
            po.SetFieldOrProperty("currentOperator", mockOp.Object);
            po.SetFieldOrProperty("mDisplayedNumber", 2);
            double[] arry = new double[]{2.0};
            mockOp.Setup(f => f.PerformOperation(arry)).Returns(3.0);

            target.AcceptEquals();

            double actual = (double)po.GetFieldOrProperty("mDisplayedNumber");
            Assert.AreEqual(3.0, actual);
            Assert.IsNull((INaryOperator)po.GetFieldOrProperty("currentOperator"));
            Assert.AreEqual(0, previouslyEnteredNumbers.Count);
        }

        /// <summary>
        /// Successful test of AcceptEquals given previous inputs
        /// </summary>
        [TestMethod]
        public void CalculatorServerTestEqualsGoodWithInputs()
        {
            previouslyEnteredNumbers.Add(1.0);
            po.SetFieldOrProperty("currentOperator", mockOp.Object);
            po.SetFieldOrProperty("mDisplayedNumber", 2);
            mockOp.Setup(f => f.PerformOperation(It.IsAny<double[]>())).Returns(3.0);

            target.AcceptEquals();

            double actual = (double)po.GetFieldOrProperty("mDisplayedNumber");
            Assert.AreEqual(3.0, actual);
            Assert.IsNull((INaryOperator)po.GetFieldOrProperty("currentOperator"));
            Assert.AreEqual(0, previouslyEnteredNumbers.Count);
        }

        /// <summary>
        /// Test when the user presses equals multiple times
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CalculatorException))]
        public void CalculatorServerTestMultipleEquals()
        {
            previouslyEnteredNumbers.Add(1.0);
            po.SetFieldOrProperty("currentOperator", mockOp.Object);
            po.SetFieldOrProperty("mDisplayedNumber", 2);
            mockOp.Setup(f => f.PerformOperation(It.IsAny<double[]>())).Returns(3.0);

            target.AcceptEquals();
            target.AcceptEquals();
        }
    }
}
