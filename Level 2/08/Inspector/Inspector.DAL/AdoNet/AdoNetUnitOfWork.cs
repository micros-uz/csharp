using Inspector.DAL.Exceptions;
using Inspector.DAL.Interfaces;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Inspector.DAL.AdoNet
{
    internal class AdoNetUnitOfWork : IUnitOfWork, IDisposable
    {
        private SqlConnection _conn;
        private SqlTransaction _tran;

        public AdoNetUnitOfWork(IConnectionFactory connFactory)
        {
            _conn = (SqlConnection)connFactory.GetConnection();
            _tran = _conn.BeginTransaction();
        }

        public void SaveChanges()
        {
            if (_tran == null)
                throw new DalException("Transaction have already been committed.");

            _tran.Commit();
            _tran = null;
        }

        public IDbCommand GetCommand()
        {
            var cmd = _conn.CreateCommand();
            cmd.Transaction = _tran;

            return cmd;
        }

        public void Dispose()
        {
            if (_tran != null)
            {
                _tran.Rollback();
                _tran = null;
            }

            if (_conn != null)
            {
                _conn.Close();
                _conn = null;
            }
        }

        public IRepository<T> GetRepository<T>() where T : new()
        {
            return new GenericRepository<T>(this);
        }
    }
}
