using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class InsertInvoiceDAO: ConnectionToSQL
    {
        public bool insertInvoiceData(string operationCode, string invoiceFilePath)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Operations SET invoiceFilePath = @invoiceFilePath WHERE idOperation = @operationCode";
                    command.Parameters.AddWithValue("@invoiceFilePath", invoiceFilePath);
                    command.Parameters.AddWithValue("@operationCode", operationCode);
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
