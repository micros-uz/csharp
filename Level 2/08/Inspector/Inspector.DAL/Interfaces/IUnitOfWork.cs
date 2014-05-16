using System.Data;
using System.Data.SqlClient;

namespace Inspector.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        IDbCommand GetCommand();

        IRepository<T> GetRepository<T>() where T : new();
    }
}
