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
    }
}
