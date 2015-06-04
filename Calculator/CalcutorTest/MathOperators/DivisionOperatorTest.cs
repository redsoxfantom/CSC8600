using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.MathOperators.BinaryOperators;
using Calculator.MathOperators;

namespace CalculatorTest.MathOperators
{
    /// <summary>
    /// Test the DivisionOperator class
    /// </summary>
    [TestClass]
    public class DivisionOperatorTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private DivisionOperator target;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            target = new DivisionOperator();
        }

        /// <summary>
        /// Test the PerformOperation method when given less than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void DivisionPerformOperationLessThanTwoOperators()
        {
            target.PerformOperation(1.0);
        }

        /// <summary>
        /// Test the PerformOperation method when given more than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void DivisionPerformOperationMoreThanTwoOperators()
        {
            target.PerformOperation(1.0,2.0,3.0);
        }

        /// <summary>
        /// Test the NumOperandsExpected() method
        /// </summary>
        [TestMethod]
        public void DivisionGetNumOperands()
        {
            int expected = 2;
            int actual = target.NumOperandsExpected();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given two whole numbers
        /// </summary>
        [TestMethod]
        public void DivisionPerformOperationWholeNumbers()
        {
            double expected = 1.5;
            double actual = target.PerformOperation(3.0, 2.0);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given fractional numbers
        /// </summary>
        [TestMethod]
        public void DivisionPerformOperationFractions()
        {
            double expected = 9.0;
            double actual = target.PerformOperation(0.9, 0.1);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given a mix of fractional and whole numbers
        /// </summary>
        [TestMethod]
        public void DivisionPerformOperationMixed()
        {
            double expected = 5.0;
            double actual = target.PerformOperation(1.0, 0.2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when attempting to divide by zero
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void DivisionPerformOperationDivideByZero()
        {
            double res = target.PerformOperation(1.0, 0.0);
        }
    }
}
