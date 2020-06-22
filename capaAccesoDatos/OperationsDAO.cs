using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class OperationsDAO: ConnectionToSQL
    {
        public DataTable OperationsData(string idUser) 
        {
            DataTable operationTable = null;
            SqlDataAdapter da;
            using (SqlConnection connection = GetConnection()) 
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idOperation as Operacion, opt.Type as Tipo, st.Status as Estatus, operationPercent as perc FROM Operations AS op INNER JOIN OperationType AS opt ON op.idOperationType = opt.idOperationType INNER JOIN OperationalStatus AS st ON op.idOperationStatus = st.idOperationalStatus WHERE idUser = @client";
                    //command.CommandText = "SELECT idOperation as Operacion, idOperationType as Tipo, idOperationStatus as Estatus FROM Operations WHERE idUser = '" + UserLoginCache.IDUser + "'";
                    command.Parameters.AddWithValue("@client", UserLoginCache.IDUser);
                    command.CommandType = CommandType.Text;
                    da = new SqlDataAdapter(command);
                    operationTable = new DataTable();
                    da.Fill(operationTable);
                }
            }
            return operationTable;
        }
    }
}
