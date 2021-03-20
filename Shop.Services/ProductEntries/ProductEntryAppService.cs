using Shop.Entities;
using Shop.Infrastructure;
using Shop.Services.ProductEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductEntries
{
    public class ProductEntryAppService : ProductEntryService
    {
        private ProductEntryRepository _productEntryRepository;
        private UnitOfWork _unitOfWork;
        public ProductEntryAppService
            (ProductEntryRepository productEntryRepository,
            UnitOfWork unitOfWork)
        {
            _productEntryRepository = productEntryRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddProductEntryDto dto)
        {
            ProductEntry productEntry = new ProductEntry()
            {
                EntryDate = dto.EntryDate,
                EntrySerialNumber = dto.EntrySerialNumber,
                ProductCount = dto.ProductCount,
                ProductId = dto.ProductId
            };
            var recordId = _productEntryRepository.Add(productEntry);
            _unitOfWork.Complete();
            return recordId;
        }
        public void Update(int id, UpdateProductEntryDto dto)
        {
            var foundedItem = _productEntryRepository.FindOneById(id);
            foundedItem.EntryDate = dto.EntryDate;
            foundedItem.EntrySerialNumber = dto.EntrySerialNumber;
            foundedItem.ProductCount = dto.ProductCount;
            foundedItem.ProductId = dto.ProductId;
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
