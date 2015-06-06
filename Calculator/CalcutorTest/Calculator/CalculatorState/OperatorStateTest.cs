using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator.CalculatorState;
using Calculator.MathOperators;
using Moq;
using System.Collections.Generic;

namespace CalcutorTest.Calculator.CalculatorState
{
    /// <summary>
    /// Test of the operator State class
    /// </summary>
    [TestClass]
    public class OperatorStateTest
    {
        /// <summary>
        /// Class under test
        /// </summary>
        private OperatorState target;

        /// <summary>
        /// Allows access to private methods and fields
        /// </summary>
        private PrivateObject po;

        /// <summary>
        /// Mocked out operator
        /// </summary>
        private Mock<INaryOperator> opMock;

        /// <summary>
        /// List of operators
        /// </summary>
        private List<INaryOperator> operatorsList;

        /// <summary>
        /// List of operands
        /// </summary>
        private List<double> operandsList;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            opMock = new Mock<INaryOperator>();
            operandsList = new List<double>();
            operatorsList = new List<INaryOperator>();
            target = new OperatorState(operandsList, operatorsList, opMock.Object);
            po = new PrivateObject(target);

            operandsList = (List<double>)po.GetFieldOrProperty("OperandList");
            operatorsList = (List<INaryOperator>)po.GetFieldOrProperty("OperatorList");
        }

        /// <summary>
        /// Test the constructor
        /// </summary>
        [TestMethod]
        public void OperatorStateTestConstructor()
        {
            INaryOperator op = (INaryOperator)po.GetFieldOrProperty("mOp");

            Assert.AreEqual(opMock.Object, op);
        }

        /// <summary>
        /// test the Operator transition method
        /// </summary>
        [TestMethod]
        public void OperatorStateTestOperatorTransition()
        {
            Mock<INaryOperator> newOp = new Mock<INaryOperator>();

            ICalculatorState newState = target.OperatorTransition(newOp.Object);

            PrivateObject newPo = new PrivateObject(newState);
            INaryOperator op = (INaryOperator)newPo.GetFieldOrProperty("mOp");
            Assert.AreEqual(newOp.Object, op);
        }

        /// <summary>
        /// test the Get Current Num method
        /// </summary>
        [TestMethod]
        public void OperatorStateTestGetCurrentNum()
        {
            operandsList.Add(1.0);
            operandsList.Add(2.0);

            String actual = target.GetCurrentNumber();

            Assert.AreEqual("2", actual);
        }
    }
}
