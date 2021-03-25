using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.Warehouses.Contracts
{
    public interface WarehouseRepository
    {
        int Add(int productCount, int productId);
        void Delete(int id);
        void CheckIfProductAmountIsSufficient(int productId);
        Warehouse Find(int id);
        GetWarehouseDto FindOneById(int id);
        List<GetWarehouseDto> GetAll();
        void ManageWarehousesAgain(int countDiffer,int productId);
        
    }
}