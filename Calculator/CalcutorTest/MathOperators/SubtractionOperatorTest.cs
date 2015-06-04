using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.MathOperators.BinaryOperators;
using Calculator.MathOperators;

namespace CalculatorTest.MathOperators
{
    /// <summary>
    /// Test the SubtractionOperator class
    /// </summary>
    [TestClass]
    public class SubtractionOperatorTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private SubtractionOperator target;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            target = new SubtractionOperator();
        }

        /// <summary>
        /// Test the PerformOperation method when given less than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void SubtractionPerformOperationLessThanTwoOperators()
        {
            target.PerformOperation(1.0);
        }

        /// <summary>
        /// Test the PerformOperation method when given more than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void SubtractionPerformOperationMoreThanTwoOperators()
        {
            target.PerformOperation(1.0,2.0,3.0);
        }

        /// <summary>
        /// Test the NumOperandsExpected() method
        /// </summary>
        [TestMethod]
        public void SubtractionGetNumOperands()
        {
            int expected = 2;
            int actual = target.NumOperandsExpected();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given two whole numbers
        /// </summary>
        [TestMethod]
        public void SubtractionPerformOperationWholeNumbers()
        {
            double expected = 2.0;
            double actual = target.PerformOperation(3.0, 1.0);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given fractional numbers
        /// </summary>
        [TestMethod]
        public void SubtractionPerformOperationFractions()
        {
            double expected = 0.8;
            double actual = target.PerformOperation(0.9, 0.1);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given a mix of fractional and whole numbers
        /// </summary>
        [TestMethod]
        public void SubtractionPerformOperationMixed()
        {
            double expected = 0.7;
            double actual = target.PerformOperation(1.0, 0.3);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when the result is negative
        /// </summary>
        [TestMethod]
        public void SubtractionPerformOperationNegative()
        {
            double expected = -0.5;
            double actual = target.PerformOperation(1.0, 1.5);

            Assert.AreEqual(expected, actual);
        }
    }
}
