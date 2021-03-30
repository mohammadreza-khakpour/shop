using System;

namespace Shop.Services.AccountingDocuments
{
    public class AddAccountingDocumentDto
    {
        public DateTime CreationDate { get; set; }
        public string SerialNumber { get; set; }
        public string SalesCheckListSerialNumber { get; set; }
        public double SalesCheckListOverallPrice { get; set; }
        public int SalesCheckListId { get; set; }
    }
}