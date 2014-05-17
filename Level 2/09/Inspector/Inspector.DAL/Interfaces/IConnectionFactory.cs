using System.Data;

namespace Inspector.DAL.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
