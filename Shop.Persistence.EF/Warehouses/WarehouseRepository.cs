using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Persistence.EF.Warehouses
{
    public interface WarehouseRepository
    {
        int Add(Warehouse warehouse);
        void Delete(Warehouse warehouse);
        GetWarehouseDto FindOneById(int id);
        List<GetWarehouseDto> GetAll();
    }
}