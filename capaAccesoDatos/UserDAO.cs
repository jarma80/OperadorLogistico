using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace DataAccess
{
    public class UserDAO:ConnectionToSQL
    {
        public bool login(string user, string pass, int rol)
        {
            if (rol == 0 || rol == 1)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        if (rol == 0)
                        {
                            command.CommandText = "SELECT * FROM Users WHERE userName = @user AND textPass = @pass";
                        }
                        else if (rol == 1)
                        {
                            command.CommandText = "SELECT * FROM OperadoresLogisticos WHERE userName = @user AND textPass = @pass";
                        }
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@pass", pass);
                        command.CommandType = CommandType.Text;
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserLoginCache.IDUser = reader[0].ToString();
                                UserLoginCache.firstName = reader[3].ToString();
                                UserLoginCache.lastName = reader[4].ToString();
                                UserLoginCache.Name = reader[5].ToString();
                                UserLoginCache.Email = reader[6].ToString();
                                UserLoginCache.Telefono = reader.GetInt64(7);
                                UserLoginCache.Rol = rol;
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
            else 
            {
                return false;
                
            }
        }
    }
}
