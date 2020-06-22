using DataAccess;
using System.Data;


namespace Domain
{
    public class OperationsTotalDetatilsModel
    {
        OperationsTotalDetatilsDAO OperationsDAO = new OperationsTotalDetatilsDAO();
        public DataTable Operations(string startDate, string endingDate)
        {
            return OperationsDAO.OperationsData(startDate, endingDate);
        }
    }
}
