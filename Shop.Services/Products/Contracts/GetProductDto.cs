namespace Shop.Persistence.EF.Products
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumAmount { get; set; }
        public int ProductCategoryId { get; set; }
        public enum Status
        {
            Insufficient,
            InOrder
        }
    }
}