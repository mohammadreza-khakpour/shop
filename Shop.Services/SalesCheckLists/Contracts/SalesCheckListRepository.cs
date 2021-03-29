using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public interface SalesCheckListRepository
    {
        SalesCheckList Add(AddSalesCheckListDto dto);
        void Delete(int id);
        SalesCheckList Find(int id);
        SalesCheckList FindAndRemoveSalesItems(int id);
        GetOneSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
    }
}