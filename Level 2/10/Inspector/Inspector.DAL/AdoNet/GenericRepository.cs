using System.Linq;
using Inspector.DAL.Exceptions;
using Inspector.DAL.Interfaces;
using Inspector.Domain.Misc;
using Inspector.Domain.Models;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Inspector.DAL.AdoNet
{
    internal class GenericRepository<T> : IRepository<T> where T : IEntity, new()
    {
        private readonly IUnitOfWork _uow;
        public GenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Add(T entity)
        {
            using(var cmd = _uow.GetCommand())
            {
                var tableName = GetTableName<T>();

                var dic = new Dictionary<string, object>();
                (entity as IEntity).Save(dic);

                var cols = string.Join(",", dic.Keys.Select(x => x));
                var values = string.Join(",", dic.Values.Select(x => "'" + x + "'"));

                cmd.CommandText = string.Format("insert into {0} ({1}) values ({2})",
                    tableName, cols, values);
                var n = cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicat)
        {
            var res = new List<T>();

            
            using (var cmd = _uow.GetCommand())
            {
                string tableName = GetTableName<T>();

                cmd.CommandText = "select * from " + tableName;

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    var obj = new T();

                    (obj as IEntity).Load(reader);

                    res.Add(obj);
                }
            }

            return (IEnumerable<T>)res;
        }

        private static string GetTableName<T>()
        {
            var attrs = typeof(T).GetCustomAttributes(false);

            string tableName = (attrs.Length == 0
                || !attrs[0].GetType().Equals(typeof(TableAttribute)))
                ? typeof(T).Name + "s"
                : (attrs[0] as TableAttribute).TableName;

            return tableName;
        }

        public void Update(T entity)
        {
        }

        public void Delete(T entity)
        {
        }
    }
}
