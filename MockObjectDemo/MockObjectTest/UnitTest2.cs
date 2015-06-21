using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockObjectDemo;
using Moq;

namespace MockObjectTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethodWithStub()
        {
            ClassUnderTest target = new ClassUnderTest();
            StubbedOutInterfaceClass stubClass = new StubbedOutInterfaceClass();

            int res = target.Search(5, stubClass);

            Assert.AreEqual(5, res);
        }

        [TestMethod]
        public void TestMethodWithMockSetup()
        {
            ClassUnderTest target = new ClassUnderTest();
            Mock<IInterfaceToMock> mockObj = new Mock<IInterfaceToMock>();
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(5)).Returns(10);

            int res = target.Search(5, mockObj.Object);

            Assert.AreEqual(10, res);
        }

        [TestMethod]
        public void TestMethodWithMultipleSetups()
        {
            ClassUnderTest target = new ClassUnderTest();
            Mock<IInterfaceToMock> mockObj = new Mock<IInterfaceToMock>();
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(1)).Returns(2);
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(2)).Returns(3);
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(4)).Returns(10);

            int res = target.Search(2, mockObj.Object);
            Assert.AreEqual(3, res);

            res = target.Search(1, mockObj.Object);
            Assert.AreEqual(2, res);

            res = target.Search(4, mockObj.Object);
            Assert.AreEqual(10, res);
        }

        [TestMethod]
        public void TestMethodWithVerify()
        {
            ClassUnderTest target = new ClassUnderTest();
            Mock<IInterfaceToMock> mockObj = new Mock<IInterfaceToMock>();
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(1)).Returns(2);

            int res = target.Search(1, mockObj.Object);

            Assert.AreEqual(2, res);
            mockObj.Verify(f => f.PerformExpensiveDatabaseLookup(1), Times.Once());
            //mockObj.Verify(f => f.PerformExpensiveDatabaseLookup(1), Times.Exactly(2));
        }

        [TestMethod]
        public void TestMethodWithException()
        {
            ClassUnderTest target = new ClassUnderTest();
            Mock<IInterfaceToMock> mockObj = new Mock<IInterfaceToMock>();
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(1)).Throws(new Exception());
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(2)).Returns(3);

            int res = target.Search(2, mockObj.Object);
            Assert.AreEqual(3, res);

            res = target.Search(1, mockObj.Object);
            Assert.AreEqual(-1, res);
        }

        [TestMethod]
        public void TestMethodWithAnyParam()
        {
            ClassUnderTest target = new ClassUnderTest();
            Mock<IInterfaceToMock> mockObj = new Mock<IInterfaceToMock>();
            mockObj.Setup(f => f.PerformExpensiveDatabaseLookup(It.IsAny<int>())).Returns(3);

            int res = target.Search(2, mockObj.Object);
            Assert.AreEqual(3, res);

            res = target.Search(5, mockObj.Object);
            Assert.AreEqual(3, res);

            res = target.Search(34, mockObj.Object);
            Assert.AreEqual(3, res);
        }
    }
}
