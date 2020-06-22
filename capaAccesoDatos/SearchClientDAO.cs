using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SearchClientDAO:ConnectionToSQL
    {
        public DataTable SearchData(string criterion) 
        {
            DataTable clientTable = null;
            SqlDataAdapter da;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idUser as Clave, Name as Nombre FROM Users WHERE Name LIKE '%"+ criterion + "%'";                    
                    //command.Parameters.AddWithValue("@client", criterion);
                    command.CommandType = CommandType.Text;
                    da = new SqlDataAdapter(command);
                    clientTable = new DataTable();
                    da.Fill(clientTable);
                }
            }

            return clientTable;
        }
    }
}
