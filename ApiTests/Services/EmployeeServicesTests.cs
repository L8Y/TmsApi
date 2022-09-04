using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Api.Services.Tests
{
    [TestClass()]
    public class EmployeeServicesTests
    {
        [TestMethod()]
        public void DeleteEmployeeByIdTest()
        {
            var data = new List<Employee>()
            {
                new Employee { Id = 1, Name ="ar", EmailId = "a@g.com,"},
                new Employee { Id = 2, Name = "asr", EmailId = "a2@g.com," },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            /*mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);*/
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<training_management_systemContext>();
            mockContext.Setup(m => m.Employees).Returns(mockSet.Object);
            //mockSet.Setup(c => c.Where(It.IsAny < Func<Employee, bool>>())).Returns(data);
            mockSet.Setup(c => c.Remove(It.IsAny<Employee>()));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            EmployeeServices es = new EmployeeServices(mockContext.Object);

            bool result = es.DeleteEmployeeById(1);
            mockSet.Verify(c => c.Remove(It.IsAny<Employee>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsTrue(result);
        }

        public void AddEmpolyeeTest()
        {
            var mockSet = new Mock<DbSet<Employee>>();
            var mockContext = new Mock<training_management_systemContext>();
            mockContext.Setup(m => m.Employees).Returns(mockSet.Object);
            Employee e = new Employee();
            e.EmailId = "qew@g.com";
            e.Name = "asd";

            
            mockSet.Setup(c => c.Add(It.IsAny<Employee>()));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            EmployeeServices es = new EmployeeServices(mockContext.Object);

            bool result = es.AddEmployeeData(e);
            mockSet.Verify(c => c.Add(It.IsAny<Employee>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.IsTrue(result);

        }
    }
}