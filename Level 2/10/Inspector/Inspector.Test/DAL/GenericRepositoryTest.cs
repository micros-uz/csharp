using Inspector.DAL.AdoNet;
using Inspector.DAL.Interfaces;
using Inspector.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
using System.Globalization;

namespace Inspector.Test.DAL
{
    [TestClass]
    public class GenericRepositoryTest
    {
        [TestMethod]
        public void AddTest()
        {
            string cmdText = null;
            var cmdMock = new Mock<IDbCommand>();
            cmdMock.SetupSet(x => x.CommandText)
                .Callback(s => cmdText = s);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetCommand())
                .Returns(cmdMock.Object);                

            var rpstr = new GenericRepository<Area>(uowMock.Object);

            var area = new Area{Name = "Test Name", SOATO = "1703"};

            rpstr.Add(area);

            cmdMock.VerifySet(x => x.CommandText);
            cmdMock.Verify(x => x.ExecuteNonQuery());

            var etalon = "insert into Areas (Name,SOATO) values ('Test Name','1703')";

            Assert.AreEqual(etalon, cmdText);
        }
    }
}
