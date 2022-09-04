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
    public class HrServicesTests
    {
        [TestMethod()]
        public void GetHrDetailsTest()
        {
            var data = new List<Hr>
            {
                new Hr { Id = 1, EmailId = "hr@g.com", Password="asd"},
                new Hr { Id = 2, EmailId = "h@g.com", Password="SAD"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Hr>>();
            mockSet.As<IQueryable<Hr>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Hr>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Hr>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Hr>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<training_management_systemContext>();
            mockContext.Setup(c => c.Hrs).Returns(mockSet.Object);

            HrServices hs = new HrServices(mockContext.Object);
            var hrData = hs.GetHrDetails();

            foreach (var hr in hrData)
            {
                Assert.IsNotNull(hr.Id);
                Assert.IsNotNull(hr.EmailId);
                Assert.IsNotNull(hr.Password);
            }
        }
        [TestMethod()]
        public void GetHrDetailsByIdTest()
        {
            var data = new List<Hr>
            {
                new Hr { Id = 1, EmailId = "hr@g.com", Password="asd"},
                new Hr { Id = 2, EmailId = "h@g.com", Password="SAD"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Hr>>();
            mockSet.As<IQueryable<Hr>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Hr>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Hr>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Hr>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<training_management_systemContext>();
            mockContext.Setup(c => c.Hrs).Returns(mockSet.Object);

            HrServices hs = new HrServices(mockContext.Object);
            var hrData = hs.GeTHrDetailsById(1);

            foreach (var hr in hrData)
            {
                Assert.AreEqual(1, hr.Id);
                Assert.AreEqual("hr@g.com", hr.EmailId);
                Assert.IsNotNull(hr.Id);
                Assert.IsNotNull(hr.EmailId);
                Assert.IsNotNull(hr.Password);
            }
        }
    }
}