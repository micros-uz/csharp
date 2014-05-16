using Inspector.DAL.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Inspector.DAL.AdoNet
{
    internal class AdoNetConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            var connStr = ConfigurationManager.ConnectionStrings["PROD_CONNSTR"];

            var providerName = connStr.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            var conn = factory.CreateConnection();

            conn.Open();

            return conn;
        }
    }
}
