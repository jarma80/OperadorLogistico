using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class OperationDetailCache
    {
        public static string idOperation { get; set; }
        public static string Type { get; set; }
        public static string Status { get; set; }
        public static DateTime OperationDate { get; set; }
        public static string Progress { get; set; }

        public static string InvoicePath { get; set; }

    }
}
