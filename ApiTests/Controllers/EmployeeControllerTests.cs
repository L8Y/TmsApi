using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Interface;
using Moq;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {
        [TestMethod()]
        public void EmployeeDeleteTest()
        {
            var employeeMock = new Mock<IEmployee>();
            employeeMock.Setup(p => p.DeleteEmployeeById(It.IsAny<int>())).Returns(true);
            EmployeeController ec = new EmployeeController(employeeMock.Object);

            var commentsResult = ec.Delete(1);

            Assert.IsTrue(commentsResult);
            
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}