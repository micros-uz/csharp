using System.Linq;
using Inspector.BLL.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspector.DAL.Interfaces;
using Moq;
using Inspector.Test.Helpers;

namespace Inspector.Test.BLL
{
    [TestClass]
    public class CatalogManagerTest
    {
        [TestMethod]
        public void GetAreTest()
        {
            var catMgr = new CatalogManager(DbContextHelper.GetCtx());

            var areas = catMgr.GetAreas();

            Assert.IsNotNull(areas);
            Assert.AreEqual(14, areas.Count());
        }

        [TestMethod]
        public void GetOrgTest()
        {
            var catMgr = new CatalogManager(DbContextHelper.GetCtx());

            var orgs = catMgr.GetOrgatizations("1726");

            Assert.IsNotNull(orgs);
            Assert.IsNotNull(orgs.First(x => x.Name == "1726_OVD"));
            Assert.IsNotNull(orgs.First(x => x.Name == "1726_Hokimiyat"));
        }
    }
}
