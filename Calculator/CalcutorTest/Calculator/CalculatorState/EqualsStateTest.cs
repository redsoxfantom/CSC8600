using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator.CalculatorState;
using System.Collections.Generic;
using Calculator.MathOperators;
using Moq;

namespace CalcutorTest.Calculator.CalculatorState
{
    /// <summary>
    /// Test of the Equals State class
    /// </summary>
    [TestClass]
    public class EqualsStateTest
    {
        /// <summary>
        /// The class under test
        /// </summary>
        private EqualsState target;

        /// <summary>
        /// Provides access to private methods and fields
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
        /// The result of the calculation
        /// </summary>
        private double result;

        /// <summary>
        /// The list of operators after the calculation is performed
        /// </summary>
        private List<INaryOperator> finalOperatorsList;

        /// <summary>
        /// The list of operands after the calculation is performed
        /// </summary>
        private List<double> finalOperandsList;

        /// <summary>
        /// Initialize the test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            operandsList = new List<double>();
            operatorsList = new List<INaryOperator>();
            op = new Mock<INaryOperator>();

            target = new EqualsState(operandsList, operatorsList);
            po = new PrivateObject(target);
        }

        /// <summary>
        /// Test the GetCurrentNum method
        /// </summary>
        [TestMethod]
        public void EqualsStateTestGetCurrentNum()
        {
            po.SetFieldOrProperty("result", 1.5);

            String expected = "1.5";
            String actual = target.GetCurrentNumber();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the Constructor when passed a single operator expecting two operands
        /// </summary>
        [TestMethod]
        public void EqualsStateTestConstructorSingleOperator()
        {
            operandsList.Clear();
            operatorsList.Clear();
            operandsList.Add(1.0);
            operandsList.Add(2.0);
            op.Setup(f => f.NumOperandsExpected()).Returns(2);
            op.Setup(f => f.PerformOperation(It.IsAny<double[]>())).Returns(3);
            operatorsList.Add(op.Object);

            target = new EqualsState(operandsList, operatorsList);

            LoadData();
            Assert.AreEqual(3, result);
            Assert.AreEqual(2, finalOperandsList.Count);
            Assert.AreEqual(3, finalOperandsList[0]);
            Assert.AreEqual(2, finalOperandsList[1]);
            Assert.AreEqual(1, finalOperatorsList.Count);
            Assert.AreEqual(op.Object, finalOperatorsList[0]);
        }

        /// <summary>
        /// Test the Constructor when passed a bad number of operands
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EqualsStateTestConstructorBadNumOperands()
        {
            operandsList.Clear();
            operatorsList.Clear();
            operandsList.Add(1.0);
            op.Setup(f => f.NumOperandsExpected()).Returns(2);
            op.Setup(f => f.PerformOperation(It.IsAny<double[]>())).Returns(3);
            operatorsList.Add(op.Object);

            target = new EqualsState(operandsList, operatorsList);
        }

        /// <summary>
        /// Load the result of the calculation and the lists
        /// </summary>
        private void LoadData()
        {
            po = new PrivateObject(target);
            result = (double)po.GetFieldOrProperty("result");
            finalOperandsList = (List<double>)po.GetFieldOrProperty("OperandList");
            finalOperatorsList = (List<INaryOperator>)po.GetFieldOrProperty("OperatorList");
        }
    }
}
