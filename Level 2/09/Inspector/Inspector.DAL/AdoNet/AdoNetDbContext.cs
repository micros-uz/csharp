using Inspector.DAL.Interfaces;

namespace Inspector.DAL.AdoNet
{
    internal class AdoNetDbContext : IDbContext
    {
        private readonly IConnectionFactory _connFactory;

        public AdoNetDbContext(IConnectionFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new AdoNetUnitOfWork(_connFactory);
        }
    }
}
