using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class OperativeStatus:ConnectionToSQL
    {
        public DataTable GetData()
        {
            DataTable operativeStatusTable = null;
            SqlDataAdapter da;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Status FROM OperationalStatus";
                    //command.Parameters.AddWithValue("@client", criterion);
                    command.CommandType = CommandType.Text;
                    da = new SqlDataAdapter(command);
                    operativeStatusTable = new DataTable();
                    da.Fill(operativeStatusTable);
                }
            }

            return operativeStatusTable;
        }
    }
}
