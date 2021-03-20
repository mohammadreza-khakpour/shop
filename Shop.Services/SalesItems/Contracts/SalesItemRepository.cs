using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Persistence.EF.SalesItems
{
    public interface SalesItemRepository
    {
        int Add(SalesItem salesItem);
        void Delete(SalesItem salesItem);
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
    }
}