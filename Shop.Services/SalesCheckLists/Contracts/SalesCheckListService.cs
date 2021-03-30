using Shop.Services.SalesCheckLists.Contracts;
using Shop.Services.SalesItems;
using System.Collections.Generic;

namespace Shop.Services.SalesCheckLists
{
    public interface SalesCheckListService
    {
        int Add(AddSalesCheckListDto dto);
        void Delete(int id);
        GetOneSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
        int Update(int id, UpdateSalesCheckListDto dto);
        void CheckIfProductsCountAreEnough(List<AddSalesItemDto> salesItems);
    }
}