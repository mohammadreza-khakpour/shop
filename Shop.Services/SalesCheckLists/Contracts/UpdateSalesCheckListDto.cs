using Shop.Services.SalesItems;
using System;
using System.Collections.Generic;

namespace Shop.Services.SalesCheckLists
{
    public class UpdateSalesCheckListDto
    {
        public string SerialNumber { get; set; }
        public string RecordDate { get; set; }
        public string CustomerFullName { get; set; }
        public List<AddSalesItemDto> SalesItems { get; set; }
    }
}