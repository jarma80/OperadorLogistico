using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class InsertClientModel
    {
        InsertClientDAO client = new InsertClientDAO();
        public bool Insert(string idClient, string userName, string textPass, string firstName, string lastName, string Name, string Email, Int64 Telefono) 
        {
            return client.insertClient(idClient, userName, textPass, firstName, lastName, Name, Email, Telefono);
        }
    }
}
