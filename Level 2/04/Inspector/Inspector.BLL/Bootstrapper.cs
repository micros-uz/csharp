using Inspector.BLL.Managers;
using Inspector.Domain.Interfaces;
using Inspector.Domain.Ioc;

namespace Inspector.BLL
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            IoC.Register<ICatalogManager, CatalogManager>();
        }
    }
}
