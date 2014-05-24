using System.Data.SqlClient;
using System.Diagnostics;
namespace Inspector.DAL
{
    public static class Db
    {
        public static void Connect()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(local)";
            builder.InitialCatalog = "Inspector";
            builder.IntegratedSecurity = true;

            var connStr = builder.ConnectionString;

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();

                var cmd = new SqlCommand("select * from areas", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader[0];
                    var name = reader[1];
                    var soato = reader[2];

                    Debug.WriteLine("{0} {1} {2}", id, name, soato);
                }
            }
        }
    }
}
