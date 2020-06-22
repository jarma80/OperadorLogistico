using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class UpdateOperationStatusModel
    {
        UpdateOperationStatusDAO updateOperation = new UpdateOperationStatusDAO();
        public bool Update(string idOperation, int statusOperativo, string status) 
        {
            return updateOperation.UpdateStatus(idOperation, statusOperativo, status);
        }
    }
}
