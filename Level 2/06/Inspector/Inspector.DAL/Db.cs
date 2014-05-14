using System.Data.SqlClient;
using System.Diagnostics;
namespace Inspector.DAL
{
    public static class Db
    {
        public static void Connect()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @".\SQLExpress";
            builder.InitialCatalog = "Inspector";
            builder.IntegratedSecurity = true;

            var connStr = builder.ConnectionString;

            using(var conn = new SqlConnection(connStr))
            {
                conn.Open();

                var cmd = new SqlCommand("select * from areas", conn);

                var reader = cmd.ExecuteReader();

                while(reader.HasRows)
                {
                    reader.Read();
                    var x = reader[1];
                    Debug.WriteLine(x);
                }
            }
        }
    }
}
