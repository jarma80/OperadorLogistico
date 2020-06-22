using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class InsertClientDAO: ConnectionToSQL
    {       
        public bool insertClient(string idClient, string userName, string textPass, string firstName, string lastName, string Name, string Email, Int64 Telefono)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "INSERT INTO Users(idUser, userName, textPass, fistName, lastName, Name, Email, Telefono)" +
                                            " VALUES(@idUser, @userName, @textPass, @firstName, @lastName, @Name, @Email, @Telefono)";

                    command.Parameters.AddWithValue("@idUser", idClient);
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@textPass", textPass);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Telefono", Telefono);

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
