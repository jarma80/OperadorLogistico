using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class OperationsTotalDetatilsDAO:ConnectionToSQL
    {
        public DataTable OperationsData(string startDate, string endingDate)
        {
            DataTable operationTable = null;
            SqlDataAdapter da;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT  OP.idOperation as Codigo, OpType.Type as Tipo, OpSt.Status as Estatus, OP.operationPercent as Avance, US.fistName, US.lastName, US.Name as Nombre FROM Operations as OP INNER JOIN OperationalStatus as OpSt ON OP.idOperationStatus = OpSt.idOperationalStatus INNER JOIN Users as US ON OP.idUser = US.idUser INNER JOIN OperationType as OpType ON OpType.idOperationType = OP.idOperationType WHERE convert(varchar, OP.operationDate, 23) >= @startDate AND convert(varchar, OP.operationDate, 23) <= @endingDate";
                    //command.CommandText = "SELECT idOperation as Operacion, idOperationType as Tipo, idOperationStatus as Estatus FROM Operations WHERE idUser = '" + UserLoginCache.IDUser + "'";
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endingDate", endingDate);
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
