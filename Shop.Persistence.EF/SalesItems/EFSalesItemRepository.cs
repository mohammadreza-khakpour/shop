using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.SalesItems
{
    public class EFSalesItemRepository : SalesItemRepository
    {
        private EFDataContext _dbContext;
        public EFSalesItemRepository(EFDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(SalesItem salesItem)
        {
            return _dbContext.SalesItems.Add(salesItem).Entity.Id;
        }
        public void Delete(SalesItem salesItem)
        {
            _dbContext.SalesItems.Remove(salesItem);
        }
        public List<GetSalesItemDto> GetAll()
        {
            return _dbContext.SalesItems.Select(_ => new GetSalesItemDto
            {
                Id = _.Id,
                ProductCount = _.ProductCount,
                ProductId = _.ProductId,
                SalesChecklistId = _.SalesChecklistId
            }).ToList();
        }
        public GetSalesItemDto FindOneById(int id)
        {
            var result = _dbContext.SalesItems.Find(id);
            return new GetSalesItemDto
            {
                Id = result.Id,
                ProductCount = result.ProductCount,
                ProductId = result.ProductId,
                SalesChecklistId = result.SalesChecklistId
            };
        }
    }
}
