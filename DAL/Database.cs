using System.Data.SqlClient;

namespace RazorProject.DAL
{
  public class Database
    {
        public static SqlConnection getConnection() {
            SqlConnectionStringBuilder sb = new();
            sb.DataSource = "localhost";
            sb.InitialCatalog = "TodoDb";
            sb.UserID = "SA";
            sb.Password = "P@ssw0rd";

            string connectionString = sb.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
