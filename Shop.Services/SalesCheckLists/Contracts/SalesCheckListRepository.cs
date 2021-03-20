using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Persistence.EF.SalesCheckLists
{
    public interface SalesCheckListRepository
    {
        int Add(SalesCheckList salesCheckList);
        void Delete(SalesCheckList salesCheckList);
        GetSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
    }
}