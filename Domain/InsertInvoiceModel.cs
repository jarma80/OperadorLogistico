using DataAccess;

namespace Domain
{
    public class InsertInvoiceModel
    {
        InsertInvoiceDAO invoice = new InsertInvoiceDAO();
        public bool Insert(string operationCode, string invoiceFilePath)
        {
            return invoice.insertInvoiceData(operationCode, invoiceFilePath);
        }
    }
}
