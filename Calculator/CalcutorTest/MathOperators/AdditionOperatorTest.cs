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
        /// Test the PerformOperation method when given the wrong number of operators
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MathOperatorException))]
        public void TestMethod1()
        {
        }
    }
}
