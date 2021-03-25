using System;

namespace Shop.Services.ProductEntries
{
    public class UpdateProductEntryDto
    {
        public int ProductCount { get; set; }
        public string EntryDate { get; set; }
        public string EntrySerialNumber { get; set; }
        public int ProductId { get; set; }
    }
}