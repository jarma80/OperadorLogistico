using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSQL
    {
        private readonly string connectionString;
        public ConnectionToSQL() 
        {
            connectionString = "Server=.\\SQLEXPRESS; DataBase=OperadorLogistico; user id = user; password = user";
            //connectionString = "Server=.\\SQLEXPRESS; DataBase=OperadorLogistico; integrated security = true";
        }

        protected SqlConnection GetConnection() 
        {
            return new SqlConnection(connectionString); 
        }
    }
}
