namespace Shop.Persistence.EF.SalesItems
{
    public class GetSalesItemDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public int SalesChecklistId { get; set; }
    }
}