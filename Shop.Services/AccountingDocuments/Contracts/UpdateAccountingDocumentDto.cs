using System;

namespace Shop.Services.AccountingDocuments
{
    public class UpdateAccountingDocumentDto
    {
        public DateTime CreationDate { get; set; }
        public string SerialNumber { get; set; }
        public int SalesCheckListId { get; set; }
    }
}