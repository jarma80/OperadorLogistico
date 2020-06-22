using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UpdateOperationStatusDAO:ConnectionToSQL
    {
        public bool UpdateStatus(string idOperation, int statusOperativo, string status) 
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    int type = Common.Cache.OperationCodeCache.Type;
                    int idStatus = 0;
                    command.Connection = connection;

                    command.CommandText = "SELECT idOperationalStatus FROM OperationalStatus WHERE Status = @status";
                    command.Parameters.AddWithValue("@status", status);
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            idStatus = reader.GetInt16(0);
                        }
                    }
                    reader.Close();

                    double percent = 0;

                    if (type == 1)
                    {
                        percent = System.Math.Round( (statusOperativo + 1 )*(100 / 8.0), 0);
                    }
                    else if(type == 2)
                    {
                        percent = System.Math.Round( (statusOperativo + 1) * (100 / 4.0), 0);
                    }
                   
                    command.CommandText = "UPDATE Operations SET idOperationStatus = @statusOperativo, operationPercent = @percent WHERE idOperation = @idOper";                    
                    command.Parameters.AddWithValue("@statusOperativo", idStatus);
                    command.Parameters.AddWithValue("@percent", percent);
                    command.Parameters.AddWithValue("@idOper", idOperation);

                    command.CommandType = CommandType.Text;
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }
    }
}
