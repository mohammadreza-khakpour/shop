﻿using Shop.Entities;
using Shop.Infrastructure;
using Shop.Services.ProductEntries.Contracts;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductEntries
{
    public class ProductEntryAppService : ProductEntryService
    {
        private ProductEntryRepository _productEntryRepository;
        private WarehouseRepository _warehouseRepository;
        private UnitOfWork _unitOfWork;
        public ProductEntryAppService
            (ProductEntryRepository productEntryRepository,
            WarehouseRepository warehouseRepository,
            UnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _productEntryRepository = productEntryRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddProductEntryDto dto)
        {
            var record = _productEntryRepository.Add(dto);
            _warehouseRepository.Add(record.ProductCount,record.ProductId);
            _unitOfWork.Complete();
            return record.Id;
        }
        public void Update(int id, UpdateProductEntryDto dto)
        {
            var foundedItem = _productEntryRepository.FindOneById(id);

            foundedItem.EntryDate = DateTime.Parse(dto.EntryDate);
            foundedItem.EntrySerialNumber = dto.EntrySerialNumber;
            int countDiffer = dto.ProductCount - foundedItem.ProductCount;
            foundedItem.ProductCount = dto.ProductCount;
            _warehouseRepository.ManageWarehousesAgain(countDiffer,foundedItem.ProductId);

            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _productEntryRepository.Delete(id);
            _unitOfWork.Complete();
        }
        public List<GetProductEntryDto> GetAll()
        {
            return _productEntryRepository.GetAll();
        }
        public GetProductEntryDto FindOneById(int id)
        {
            return _productEntryRepository.FindOneById(id);
        }
    }
}
