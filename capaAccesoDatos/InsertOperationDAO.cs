using System;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class InsertOperationDAO: ConnectionToSQL
    {
        public bool insertOperation(string user, int operType)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT COUNT(numOp) as cantidad FROM Operations";
                    command.CommandType = CommandType.Text;
                    Int32 numeroOp = (Int32)command.ExecuteScalar() + 1;
                    string id_Operation = "FAIL";
                    int opPercent = 0;
                    int statusOperativo = 0;
                    int year = DateTime.Now.Year;


                    if (numeroOp >= 0 && numeroOp <= 9)
                    {
                        id_Operation = "CYL_" + year + "_00" + numeroOp;
                    }else if (numeroOp > 9 && numeroOp <= 99)
                    {
                        id_Operation = "CYL_" + year + "_0" + numeroOp;
                    }else if (numeroOp > 99 && numeroOp <= 999)
                    {
                        id_Operation = "CYL_" + year + "_" + numeroOp;
                    }

                    string initialStatus = "";
                    string sType = "";
                    if (operType == 1)
                    {
                        statusOperativo = 4;
                        opPercent = 10;
                        initialStatus = "Revalidación";
                        sType = "Aduana-Logística";
                    }
                    else if (operType == 2)
                    {
                        statusOperativo = 1;
                        initialStatus = "Carga";
                        sType = "Logística";
                        opPercent = 25;
                    }

                    command.CommandText = "INSERT INTO Operations(idOperation, idUser, idOperationType, idOperationStatus, operationDate, operationPercent, idLogisticOperator)" +
                                          " VALUES(@idOper, @user, @type, @statusOperativo, GETDATE(), @opPercent, @idLogOperator)";
                    
                    command.Parameters.AddWithValue("@idOper", id_Operation);
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@type", operType);
                    command.Parameters.AddWithValue("@statusOperativo", statusOperativo);
                    command.Parameters.AddWithValue("@opPercent", opPercent);
                    command.Parameters.AddWithValue("@idLogOperator", UserLoginCache.IDUser);

                    command.CommandType = CommandType.Text;
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        ClientCodeCache.Code = user;
                        OperationDetailCache.idOperation = id_Operation;
                        OperationDetailCache.Type = sType;
                        OperationDetailCache.Status = initialStatus;
                        OperationDetailCache.Progress = opPercent.ToString();
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
