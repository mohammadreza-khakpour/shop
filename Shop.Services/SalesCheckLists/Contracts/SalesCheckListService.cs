using Shop.Services.SalesCheckLists.Contracts;
using System.Collections.Generic;

namespace Shop.Services.SalesCheckLists
{
    public interface SalesCheckListService
    {
        int Add(AddSalesCheckListDto dto);
        void Delete(int id);
        GetOneSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
        void Update(int id, UpdateSalesCheckListDto dto);
    }
}