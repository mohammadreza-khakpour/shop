using Shop.Services.SalesItems.Contracts;
using System.Collections.Generic;

namespace Shop.Services.SalesItems
{
    public interface SalesItemService
    {
        int Add(AddSalesItemDto dto);
        void Delete(int id);
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
        void Update(int id, UpdateSalesItemDto dto);
    }
}