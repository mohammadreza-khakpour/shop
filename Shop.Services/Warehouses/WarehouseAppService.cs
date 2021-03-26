using Shop.Entities;
using Shop.Infrastructure;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Warehouses
{
    public class WarehouseAppService : WarehouseService
    {
        private WarehouseRepository _warehouseRepository;
        private UnitOfWork _unitOfWork;
        public WarehouseAppService(WarehouseRepository warehouseRepository, UnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            _warehouseRepository.Delete(id);
            _unitOfWork.Complete();
        }
        public List<RecordsWithSameProductIdInProducts> GetAll()
        {
            return _warehouseRepository.GetAll();
        }
        public GetWarehouseDto FindOneById(int id)
        {
            return _warehouseRepository.FindOneById(id);
        }
    }
}
