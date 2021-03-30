using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.SalesItems.Contracts
{
    public interface SalesItemRepository
    {
        SalesItem Add(AddSalesItemDto salesItemDto);
        void DeleteAllItemsByCheckListId(int id);
        //SalesItem Find(int id);
        GetSalesItemDto FindOneById(int id);
        List<GetSalesItemDto> GetAll();
    }
}