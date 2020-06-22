using System.Data;
using DataAccess;

namespace Domain
{
    public class SearchClientModel
    {
        SearchClientDAO searchDAO = new SearchClientDAO();
        public DataTable Search(string criterion) 
        {
            return searchDAO.SearchData(criterion);
        }
    }
}
