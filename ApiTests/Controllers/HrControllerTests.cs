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
    public class HrControllerTests
    {
        [TestMethod()]
        public void getHrTest()
        {
            var hrMock = new Mock<IHr>();
            hrMock.Setup(p => p.GetHrDetails()).Returns(new List<Hr>
            {
                new Hr { Id = 1, EmailId = "hr@g.com", Password="asd"},
                new Hr { Id = 2, EmailId = "h@g.com", Password="SAD"}
            });

            HrController hr = new HrController(hrMock.Object);

            var Result = hr.Get();
            Assert.IsInstanceOfType(Result, typeof(IEnumerable<Hr>));
            Assert.AreEqual(2, Result.Count());
        }
        [TestMethod()]
        public void getHrByIdTest()
        {
            var hrMock = new Mock<IHr>();
            hrMock.Setup(p => p.GetHrDetails()).Returns(new List<Hr>
            {
                new Hr { Id = 1, EmailId = "hr@g.com", Password="asd"},
                new Hr { Id = 2, EmailId = "h@g.com", Password="SAD"}
            });

            HrController hr = new HrController(hrMock.Object);

            var Result = hr.Get();
            Assert.IsInstanceOfType(Result, typeof(IEnumerable<Hr>));
            Assert.AreEqual(2, Result.Count());
        }
    }
}