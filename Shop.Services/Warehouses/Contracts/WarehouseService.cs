using Shop.Services.Warehouses.Contracts;
using System.Collections.Generic;

namespace Shop.Services.Warehouses
{
    public interface WarehouseService
    {
        void Delete(int id);
        GetWarehouseDto FindOneById(int id);
        List<RecordsWithSameProductIdInProducts> GetAll();
    }
}