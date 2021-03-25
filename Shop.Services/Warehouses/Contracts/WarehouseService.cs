using Shop.Services.Warehouses.Contracts;
using System.Collections.Generic;

namespace Shop.Services.Warehouses
{
    public interface WarehouseService
    {
        //int Add(int count, int id);
        void Delete(int id);
        GetWarehouseDto FindOneById(int id);
        List<GetWarehouseDto> GetAll();
        void Update(int id, UpdateWarehouseDto dto);
    }
}