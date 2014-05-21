using Inspector.Domain.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inspector.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IDbCommand GetCommand();

        IRepository<T> GetRepository<T>() where T : IEntity, new();
    }
}
