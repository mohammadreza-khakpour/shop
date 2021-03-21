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
        public int Add(AddWarehouseDto dto)
        {
            Warehouse warehouse = new Warehouse
            {
                ProductCount = dto.ProductCount,
                ProductId = dto.ProductId,
            };
            var recordId = _warehouseRepository.Add(warehouse);
            _unitOfWork.Complete();
            return recordId;
        }
        public void Update(int id, UpdateWarehouseDto dto)
        {
            var res = _warehouseRepository.Find(id);
            res.ProductCount = dto.ProductCount;
            res.ProductId = dto.ProductId;
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _warehouseRepository.Delete(id);
        }
        public List<GetWarehouseDto> GetAll()
        {
            return _warehouseRepository.GetAll();
        }
        public GetWarehouseDto FindOneById(int id)
        {
            return _warehouseRepository.FindOneById(id);
        }
    }
}
