using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class InsertOperationModel
    {
        InsertOperationDAO operation = new InsertOperationDAO();

        public bool Insert(string user, int operType) 
        {
            return operation.insertOperation(user, operType);
        }

    }
}
