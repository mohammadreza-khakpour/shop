namespace Shop.Services.SalesItems
{
    public class AddSalesItemDto
    {
        public int ProductCount { get; set; }
        public string ProductCode { get; set; }
        public double ProductPrice { get; set; }
        public int ProductId { get; set; }
    }
}