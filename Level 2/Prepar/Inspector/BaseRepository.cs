using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Univer.DataAccess;

namespace Univer.Models
{
    public class BaseRepository
    {
        public IEnumerable<T> Get<T>() where T : PersistEntity, new()
        {
            var res = new List<T>();

            // бывшая typeof(T).Name + "s"
            var tableName = GetTableName(typeof(T));

            // бывшая new SqlConnection("Data Source=(local);Initial Catalog=Univer;User ID=sa;Password=dev1234")
            var sqlConn = GetSqlConn();

            sqlConn.Open();

            var cmd = new SqlCommand(string.Format("select * from {0}", tableName), sqlConn);

            var rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    PersistEntity obj = new T();
                    obj.Load(rd);
                    res.Add((T)obj);
                }
            }

            sqlConn.Close();

            return res;
        }

        private static SqlConnection GetSqlConn()
        {
            return new SqlConnection(Univer.DataAccess.Univer.Default.ConnectionString);
            //return new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Univer;User ID=sa;Password=dev1234");
        }

        private static string GetTableName(Type type)
        {
            return type.Name + "s";
        }

        public void Add(PersistEntity obj)
        {
            var tableName = GetTableName(obj.GetType());

            var sqlConn = GetSqlConn();

            sqlConn.Open();

            var storageDic = new Dictionary<string, object>();
            obj.Save(storageDic);

            var cmd = new SqlCommand(string.Format("insert into {0} ({1}) values ({2})", tableName,
                string.Join(",", storageDic.Keys.Select(x => x)),
                string.Join(",", storageDic.Values.Select(x => "'" + x + "'"))), sqlConn);

            try
            {
                int rd = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new DuplicateEntityException(obj.GetType().Name);
                else
                    throw;
            }

            sqlConn.Close();
        }

        public void Delete<T>(int id) where T : PersistEntity, new()
        {
            var tableName = GetTableName(typeof(T));

            var sqlConn = GetSqlConn();

            sqlConn.Open();

            var cmd = new SqlCommand(string.Format("delete from {0} where {1}Id = {2}", tableName, typeof(T).Name, id.ToString()), sqlConn);

            int rd = cmd.ExecuteNonQuery();

            sqlConn.Close();
        }


        public void update(PersistEntity obj, string propName)
        {
            var tableName = GetTableName(obj.GetType());

            var sqlConn = GetSqlConn();

            sqlConn.Open();

            var storageDic = new Dictionary<string, object>();
            obj.Save(storageDic);
            var entityName = obj.GetType().Name;

            var cmd = new SqlCommand(string.Format("update {0} set {1} = {2} where {3}Id = {4}", tableName,
                propName, "'" + storageDic[propName] + "'", entityName, 
                obj.Id), sqlConn);

            try
            {
                int rd = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new DuplicateEntityException(obj.GetType().Name);
                else
                    throw;
            }

            sqlConn.Close();
        }
    }
}
