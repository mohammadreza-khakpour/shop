using System;

namespace Shop.Persistence.EF.AccountingDocuments
{
    public class GetAccountingDocumentDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string SerialNumber { get; set; }
        public int SalesCheckListId { get; set; }
    }
}