using Inspector.DAL.Interfaces;
using Inspector.Domain.Ioc;
using Inspector.DAL.AdoNet;

namespace Inspector.DAL
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            IoC.Register<IDbContext, AdoNetDbContext>();
            IoC.Register<IUnitOfWork, AdoNetUnitOfWork>();
            IoC.Register<IConnectionFactory, AdoNetConnectionFactory>();
        }
    }
}
