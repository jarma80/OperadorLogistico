using DataAccess;
using System.Data;

namespace Domain
{
    public class OperationDetailModel
    {
        OperationDetailsDAO operationDetails = new OperationDetailsDAO();
        public bool Details()
        {
            return operationDetails.getDetails();
        }
    }
}
