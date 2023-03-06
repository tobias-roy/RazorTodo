using System.Data.SqlClient;

namespace RazorProject.DAL
{
  public class Database
    {
        private static string connectionString(){
            SqlConnectionStringBuilder sb = new(){
                DataSource = "localhost,1433",
                InitialCatalog = "TodoDb",
                UserID = "SA",
                Password = "P@ssw0rd"
            };
            return sb.ToString();
        }
        public static SqlConnection getConnection() {
            SqlConnection connection = new SqlConnection(connectionString());
            connection.Open();
            return connection;
        }

        public static bool CheckConnection() {
            SqlConnection connection = new SqlConnection(connectionString());
            try {
                connection.Open();
                return true;
            } 
            catch (SqlException error) {
                Console.Write(error);
                return false;
            }
            finally {
                connection.Dispose();
            }
        }
    }
}
