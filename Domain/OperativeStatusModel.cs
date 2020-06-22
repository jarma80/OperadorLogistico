using System.Data;
using DataAccess;

namespace Domain
{
    public class OperativeStatusModel
    {
        OperativeStatus status = new OperativeStatus();
        public DataTable GetData() 
        {
            return status.GetData();
        }
    }
}
