using System;

namespace Shop.Persistence.EF.ProductEntries
{
    public class GetProductEntryDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntrySerialNumber { get; set; }
        public int ProductId { get; set; }
    }
}