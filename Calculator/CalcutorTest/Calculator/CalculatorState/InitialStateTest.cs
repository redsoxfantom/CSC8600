using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator.CalculatorState;
using System.Collections.Generic;
using Calculator.MathOperators;
using Moq;

namespace CalcutorTest.Calculator.CalculatorState
{
    /// <summary>
    /// Test cases for the InitialState class
    /// </summary>
    [TestClass]
    public class InitialStateTest
    {
        /// <summary>
        /// Class under test
        /// </summary>
        private InitialState target;

        /// <summary>
        /// Allows access to private members
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// The list of operands for this test
        /// </summary>
        private List<double> OperandList;

        /// <summary>
        /// The list of operators for this test
        /// </summary>
        private List<INaryOperator> OperatorList;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void InitializeTest()
        {
            target = new InitialState();
            po = new PrivateObject(target);

            OperandList = (List<double>)po.GetFieldOrProperty("OperandList");
            OperatorList = (List<INaryOperator>)po.GetFieldOrProperty("OperatorList");
        }

        /// <summary>
        /// Test the constructor
        /// </summary>
        [TestMethod]
        public void InitialStateTestConstructor()
        {
            Assert.IsNotNull(OperandList);
            Assert.IsNotNull(OperatorList);
        }

        /// <summary>
        /// Test the GetCurrentNumber method
        /// </summary>
        [TestMethod]
        public void InitialStateTestGetNum()
        {
            string expected = "0";
            string actual = target.GetCurrentNumber();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the Equals transition method
        /// </summary>
        [TestMethod]
        public void InitialStateTestEqualsTransition()
        {
            ICalculatorState actual = target.EqualsTransition();

            Assert.AreEqual(target, actual);
        }

        /// <summary>
        /// Test the Operator transition method
        /// </summary>
        [TestMethod]
        public void InitialStateTestOperatorTransition()
        {
            Mock<INaryOperator> opMock = new Mock<INaryOperator>();
            ICalculatorState actual = target.OperatorTransition(opMock.Object);

            Assert.AreEqual(target, actual);
        }

        /// <summary>
        /// Test the Operand transition method when given a bad number
        /// </summary>
        [TestMethod]
        public void InitialStateTestOperandTransitionError()
        {
            ICalculatorState newState = target.OperandTransition("BAD_NUM");

            Assert.AreEqual(newState, target);
        }

        /// <summary>
        /// Test of the Operand transition method
        /// </summary>
        [TestMethod]
        public void InitialStateTestOperandTransitionSuccess()
        {
            OperandState newState = (OperandState)target.OperandTransition("1");

            PrivateObject newPo = new PrivateObject(newState);
            List<double> newOperands = (List<double>)newPo.GetFieldOrProperty("OperandList");
            List<INaryOperator> newOperators = (List<INaryOperator>)newPo.GetFieldOrProperty("OperatorList");
            Assert.AreEqual(newOperands, OperandList);
            Assert.AreEqual(newOperators, OperatorList);
            double mCurrentNumber = (double)newPo.GetFieldOrProperty("mCurrentNumber");
            Assert.AreEqual(1, mCurrentNumber);
        }
    }
}
