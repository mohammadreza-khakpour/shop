using Shop.Services.Warehouses.Contracts;
using System.Collections.Generic;

namespace Shop.Services.Warehouses
{
    public interface WarehouseService
    {
        List<GetWarehousesGroupedByProductIdDto> GetAll();
        void ManageWarehousesAgain(int countDiffer, int productId);
        void ForAllChecklistItemsManageWarehousesAgain(int id);
        void PrepareWarehousesForChecklistUpdate(int checklistId);
    }
}