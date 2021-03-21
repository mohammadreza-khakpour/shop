using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.Warehouses.Contracts
{
    public interface WarehouseRepository
    {
        int Add(Warehouse warehouse);
        void Delete(int id);
        Warehouse Find(int id);
        GetWarehouseDto FindOneById(int id);
        List<GetWarehouseDto> GetAll();
    }
}