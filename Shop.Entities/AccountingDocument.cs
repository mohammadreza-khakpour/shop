﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entities
{
    public class AccountingDocument
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string SerialNumber { get; set; }
        public string SalesCheckListSerialNumber { get; set; }
        public double SalesCheckListOverallPrice { get; set; }
        public int SalesCheckListId { get; set; }
        public SalesCheckList SalesCheckList { get; set; }

    }
}
