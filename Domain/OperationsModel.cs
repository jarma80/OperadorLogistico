using DataAccess;
using System.Data;

namespace Domain
{
    public class OperationsModel
    {
        OperationsDAO operationsDAO = new OperationsDAO();
        public DataTable Operations(string idUser) 
        {
            return operationsDAO.OperationsData(idUser);
        }
    }
}
