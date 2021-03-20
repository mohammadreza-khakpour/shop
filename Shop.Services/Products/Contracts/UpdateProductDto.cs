using Shop.Entities;

namespace Shop.Services.Products
{
    public class UpdateProductDto
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int MinimumAmount { get; set; }
        public int ProductCategoryId { get; set; }
        public Status Status { get; set; }
    }
}