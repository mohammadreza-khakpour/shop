using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class SalesCheckList
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime RecordDate { get; set; }
        public List<SalesItem> Items { get; set; }
        public List<AccountingDocument> Documents { get; set; }
    }
}
