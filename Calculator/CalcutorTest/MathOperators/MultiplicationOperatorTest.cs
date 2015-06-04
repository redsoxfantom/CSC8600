using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.MathOperators.BinaryOperators;
using Calculator.MathOperators;

namespace CalculatorTest.MathOperators
{
    /// <summary>
    /// Test the MultiplicationOperator class
    /// </summary>
    [TestClass]
    public class MultiplicationOperatorTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private MultiplicationOperator target;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            target = new MultiplicationOperator();
        }

        /// <summary>
        /// Test the PerformOperation method when given less than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void MultiplicationPerformOperationLessThanTwoOperators()
        {
            target.PerformOperation(1.0);
        }

        /// <summary>
        /// Test the PerformOperation method when given more than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void MultiplicationPerformOperationMoreThanTwoOperators()
        {
            target.PerformOperation(1.0,2.0,3.0);
        }

        /// <summary>
        /// Test the NumOperandsExpected() method
        /// </summary>
        [TestMethod]
        public void MultiplicationGetNumOperands()
        {
            int expected = 2;
            int actual = target.NumOperandsExpected();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given two whole numbers
        /// </summary>
        [TestMethod]
        public void MultiplicationPerformOperationWholeNumbers()
        {
            double expected = 6.0;
            double actual = target.PerformOperation(3.0, 2.0);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given fractional numbers
        /// </summary>
        [TestMethod]
        public void MultiplicationPerformOperationFractions()
        {
            double expected = 0.81;
            double actual = target.PerformOperation(0.9, 0.9);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given a mix of fractional and whole numbers
        /// </summary>
        [TestMethod]
        public void MultiplicationPerformOperationMixed()
        {
            double expected = 0.3;
            double actual = target.PerformOperation(1.0, 0.3);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when one number is negative
        /// </summary>
        [TestMethod]
        public void MultiplicationPerformOperationOneNegative()
        {
            double expected = -1.5;
            double actual = target.PerformOperation(1.0, -1.5);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when both numbers are negative
        /// </summary>
        [TestMethod]
        public void MultiplicationPerformOperationTwoNegative()
        {
            double expected = 1.5;
            double actual = target.PerformOperation(-1.0, -1.5);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the commutative property of the perform operation method
        /// </summary>
        [TestMethod]
        public void MultiplicationPerformOperationCommutative()
        {
            double num1 = target.PerformOperation(5.4, 3.2);
            double num2 = target.PerformOperation(3.2, 5.4);

            Assert.AreEqual(num1, num2);
        }
    }
}
