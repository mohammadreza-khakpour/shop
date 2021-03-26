namespace Shop.Services.Warehouses.Contracts
{
    public class GetWarehouseDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductTitle { get; set; }
        public int ProductMinimumAmount { get; set; }
        public bool ProductIsSufficientInStore { get; set; }
        public int ProductCategoryId { get; set; }

    }
}