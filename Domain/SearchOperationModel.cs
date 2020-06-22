using System.Data;
using DataAccess;

namespace Domain
{
    public class SearchOperationModel
    {
        SearchOperationDAO operationDAO = new SearchOperationDAO();
        public DataTable Search(string criterion) 
        {
            return operationDAO.SearchData(criterion);
        }
    }
}
