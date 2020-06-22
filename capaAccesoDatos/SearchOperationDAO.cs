using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class SearchOperationDAO:ConnectionToSQL
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
                    //command.CommandText = "SELECT idOperation as Codigo, idUser as Cliente, OpSt.Status as Estatus, OP.operationPercent as Avance, OP.idOperationType as Type FROM Operations as OP INNER JOIN OperationalStatus as OpSt ON OP.idOperationStatus = OpSt.idOperationalStatus WHERE idOperation = @idOper";
                    command.CommandText = "SELECT OP.idOperation as Codigo, OP.idUser as Cliente, OpSt.Status as Estatus, OP.operationPercent as Avance, OP.idOperationType as Type, US.fistName, US.lastName, US.Name FROM Operations as OP INNER JOIN OperationalStatus as OpSt ON OP.idOperationStatus = OpSt.idOperationalStatus INNER JOIN Users as US ON OP.idUser = US.idUser WHERE idOperation = @idOper";
                    command.Parameters.AddWithValue("@idOper", criterion);
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
