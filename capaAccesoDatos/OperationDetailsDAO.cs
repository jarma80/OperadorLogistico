using System.Data;
using System.Data.SqlClient;
using Common.Cache;
using System;

namespace DataAccess
{
    public class OperationDetailsDAO: ConnectionToSQL
    {
        public bool getDetails()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idOperation as Operacion, opt.Type as Tipo, st.Status as Estatus, operationDate as Fecha, invoiceFilePath as Ruta FROM Operations AS op INNER JOIN OperationType AS opt ON op.idOperationType = opt.idOperationType INNER JOIN OperationalStatus AS st ON op.idOperationStatus = st.idOperationalStatus WHERE idOperation = @oper AND idUser = @user";
                    command.Parameters.AddWithValue("@oper", OperationCodeCache.Code);
                    command.Parameters.AddWithValue("@user", UserLoginCache.IDUser);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OperationDetailCache.idOperation = reader[0].ToString();
                            OperationDetailCache.Type = reader[1].ToString();
                            OperationDetailCache.Status = reader[2].ToString();
                            OperationDetailCache.OperationDate = DateTime.Parse(reader[3].ToString());
                            OperationDetailCache.InvoicePath = reader[4].ToString();
                        }
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
