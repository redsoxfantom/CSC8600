using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.MathOperators.BinaryOperators;
using Calculator.MathOperators;

namespace CalcutorTest.MathOperators
{
    /// <summary>
    /// Test the AdditionOperator class
    /// </summary>
    [TestClass]
    public class AdditionOperatorTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private AdditionOperator target;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            target = new AdditionOperator();
        }

        /// <summary>
        /// Test the PerformOperation method when given less than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void AdditionPerformOperationLessThanTwoOperators()
        {
            target.PerformOperation(1.0);
        }

        /// <summary>
        /// Test the PerformOperation method when given more than two operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void AdditionPerformOperationMoreThanTwoOperators()
        {
            target.PerformOperation(1.0,2.0,3.0);
        }

        /// <summary>
        /// Test the NumOperandsExpected() method
        /// </summary>
        [TestMethod]
        public void AdditionGetNumOperands()
        {
            int expected = 2;
            int actual = target.NumOperandsExpected();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given two whole numbers
        /// </summary>
        [TestMethod]
        public void AdditionPerformOperationWholeNumbers()
        {
            double expected = 5.0;
            double actual = target.PerformOperation(2.0, 3.0);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given fractional numbers
        /// </summary>
        [TestMethod]
        public void AdditionPerformOperationFractions()
        {
            double expected = 1.5;
            double actual = target.PerformOperation(0.8, 0.7);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the perform operation method when given a mix of fractional and whole numbers
        /// </summary>
        [TestMethod]
        public void AdditionPerformOperationMixed()
        {
            double expected = 1.3;
            double actual = target.PerformOperation(1.0, 0.3);

            Assert.AreEqual(expected, actual);
        }
    }
}
