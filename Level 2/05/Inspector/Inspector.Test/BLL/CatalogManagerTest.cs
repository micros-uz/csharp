using System.Linq;
using Inspector.BLL.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inspector.Test.BLL
{
    [TestClass]
    public class CatalogManagerTest
    {
        [TestMethod]
        public void GetAreTest()
        {
            var catMgr = new CatalogManager();

            var areas = catMgr.GetAreas();

            Assert.IsNotNull(areas);
            Assert.AreEqual(14, areas.Count());
        }

        [TestMethod]
        public void GetOrgTest()
        {
            var catMgr = new CatalogManager();

            var orgs = catMgr.GetOrgatizations("1726");

            Assert.IsNotNull(orgs);
            Assert.IsNotNull(orgs.First(x => x.Name == "1726_OVD"));
            Assert.IsNotNull(orgs.First(x => x.Name == "1726_Hokimiyat"));
        }
    }
}
