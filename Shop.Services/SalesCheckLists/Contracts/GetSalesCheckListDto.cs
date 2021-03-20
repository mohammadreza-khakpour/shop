using System;

namespace Shop.Persistence.EF.SalesCheckLists
{
    public class GetSalesCheckListDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime RecordDate { get; set; }
    }
}