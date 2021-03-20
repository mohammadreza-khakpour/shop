﻿using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.SalesCheckLists.Contracts
{
    public interface SalesCheckListRepository
    {
        int Add(SalesCheckList salesCheckList);
        void Delete(int id);
        SalesCheckList Find(int id);
        GetSalesCheckListDto FindOneById(int id);
        List<GetSalesCheckListDto> GetAll();
    }
}