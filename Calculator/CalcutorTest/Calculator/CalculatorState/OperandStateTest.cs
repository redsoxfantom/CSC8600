using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator.CalculatorState;
using System.Collections.Generic;
using Calculator.MathOperators;
using Moq;
using Calculator.Calculator;

namespace CalcutorTest.Calculator.CalculatorState
{
    /// <summary>
    /// Test of the OperandState class
    /// </summary>
    [TestClass]
    public class OperandStateTest
    {
        /// <summary>
        /// Class under test
        /// </summary>
        private OperandState target;

        /// <summary>
        /// Allows access to private members
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// List of operators
        /// </summary>
        private List<INaryOperator> operatorsList;

        /// <summary>
        /// List of operands
        /// </summary>
        private List<double> operandsList;

        /// <summary>
        /// A mocked out operator
        /// </summary>
        private Mock<INaryOperator> op;

        /// <summary>
        /// The current number of the OperandState
        /// </summary>
        private double mCurrentNumber;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            op = new Mock<INaryOperator>();
            operandsList = new List<double>();
            operatorsList = new List<INaryOperator>();
        }

        /// <summary>
        /// Test the constructor when given an invalid initial operand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CalculatorException))]
        public void OperandStateTestConstructorBadNum()
        {
            target = new OperandState(operandsList, operatorsList, "BAD_NUM");
        }

        /// <summary>
        /// Successful test of the constructor when given a valid number
        /// </summary>
        [TestMethod]
        public void OperandStateTestConstructor()
        {
            List<double> expectedOperands = new List<double>();
            List<INaryOperator> expectedOperators = new List<INaryOperator>();

            target = new OperandState(expectedOperands, expectedOperators, "1");

            po = new PrivateObject(target);
            LoadValues();
            Assert.AreEqual(expectedOperators, operatorsList);
            Assert.AreEqual(expectedOperands, operandsList);
            Assert.AreEqual(1, mCurrentNumber);
        }

        /// <summary>
        /// Test the basic constructor
        /// </summary>
        [TestMethod]
        public void OperandStateTestBasicConstructor()
        {
            List<double> expectedOperands = new List<double>();
            List<INaryOperator> expectedOperators = new List<INaryOperator>();

            target = new OperandState(expectedOperands, expectedOperators);

            po = new PrivateObject(target);
            LoadValues();
            Assert.AreEqual(expectedOperators, operatorsList);
            Assert.AreEqual(expectedOperands, operandsList);
            Assert.AreEqual(0, mCurrentNumber);

        }

        /// <summary>
        /// Test the GetCurrentNum method
        /// </summary>
        [TestMethod]
        public void OperandStateTestGetCurrentNum()
        {
            target = new OperandState(operandsList, operatorsList, "1");

            string expected = "1";
            string actual = target.GetCurrentNumber();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the OperandTransition method when given a bad number
        /// </summary>
        [TestMethod]
        public void OperandStateTestFailedOperandTransition()
        {
            InitializeTarget();

            ICalculatorState newState = target.OperandTransition("BAD_NUM");

            Assert.AreEqual(target, newState);
            PrivateObject newPo = new PrivateObject(newState);
            mCurrentNumber = (double)newPo.GetFieldOrProperty("mCurrentNumber");
            Assert.AreEqual(0, mCurrentNumber);
        }

        /// <summary>
        /// Test the OperandTransition method when given a good number
        /// </summary>
        [TestMethod]
        public void OperandStateTestOperandTransition()
        {
            InitializeTarget();

            ICalculatorState newState = target.OperandTransition("1");

            Assert.AreNotEqual(target, newState);
            Assert.IsInstanceOfType(newState, typeof(OperandState));
            Assert.AreEqual("1", newState.GetCurrentNumber());
        }

        /// <summary>
        /// Test the OperandTransition method when executed multiple times
        /// </summary>
        [TestMethod]
        public void OperandStateTestOperandMultipleTransitions()
        {
            InitializeTarget();

            ICalculatorState newState = target.OperandTransition("1");
            newState = newState.OperandTransition("2");
            newState = newState.OperandTransition("3");

            Assert.AreEqual("123", newState.GetCurrentNumber());
        }

        /// <summary>
        /// Test the operand transition method when executed with a decimal at the end
        /// </summary>
        [TestMethod]
        public void OperandStateTestOperandDecimalEndTransition()
        {
            InitializeTarget();

            ICalculatorState newState = target.OperandTransition("1");
            newState = newState.OperandTransition(".");

            Assert.AreEqual("1", newState.GetCurrentNumber());
        }

        /// <summary>
        /// Test the operand transition method when a decimal is placed in the middle
        /// </summary>
        [TestMethod]
        public void OperandStateTestOperandDecimalTransition()
        {
            InitializeTarget();

            ICalculatorState newState = target.OperandTransition("1");
            newState = newState.OperandTransition(".");
            newState = newState.OperandTransition("2");


            Assert.AreEqual("1.2", newState.GetCurrentNumber());
        }

        /// <summary>
        /// Test the operand transition method when multiple decimals are added 
        /// </summary>
        [TestMethod]
        public void OperandStateTestOperandMultipleDecimals()
        {
            InitializeTarget();

            ICalculatorState newState = target.OperandTransition("1");
            newState = newState.OperandTransition(".");
            newState = newState.OperandTransition("2");
            ICalculatorState finalState = newState.OperandTransition(".");

            Assert.AreEqual(finalState, newState);
        }

        /// <summary>
        /// Test the operator transition method
        /// </summary>
        [TestMethod]
        public void OperandStateTestOperatorTransition()
        {
            InitializeTarget();
            po.SetFieldOrProperty("mCurrentNumber", 1.5);

            ICalculatorState newState = target.OperatorTransition(op.Object);

            Assert.IsInstanceOfType(newState, typeof(OperatorState));
            PrivateObject newPo = new PrivateObject(newState);
            List<double> newList = (List<double>)newPo.GetFieldOrProperty("OperandList");
            Assert.AreEqual(1, newList.Count);
            Assert.AreEqual(1.5, newList[0]);
        }

        /// <summary>
        /// Test the Equals Transition
        /// </summary>
        [TestMethod]
        public void OperandStateTestEqualsTransitionn()
        {
            InitializeTarget();
            po.SetFieldOrProperty("mCurrentNumber", 1.5);

            ICalculatorState newState = target.EqualsTransition();

            Assert.IsInstanceOfType(newState, typeof(EqualsState));
            PrivateObject newPo = new PrivateObject(newState);
            List<double> newList = (List<double>)newPo.GetFieldOrProperty("OperandList");
            Assert.AreEqual(1, newList.Count);
            Assert.AreEqual(1.5, newList[0]);
        }

        /// <summary>
        /// Call generic constructor on target and get the lists from it
        /// </summary>
        private void InitializeTarget()
        {
            target = new OperandState(operandsList, operatorsList);
            po = new PrivateObject(target);
            LoadValues();
        }

        /// <summary>
        /// Get the operand and operator lists and the current value
        /// </summary>
        private void LoadValues()
        {
            operandsList = (List<double>)po.GetFieldOrProperty("OperandList");
            operatorsList = (List<INaryOperator>)po.GetFieldOrProperty("OperatorList");
            mCurrentNumber = (double)po.GetFieldOrProperty("mCurrentNumber");
        }
    }
}
