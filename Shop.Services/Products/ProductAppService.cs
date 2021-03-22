using Shop.Entities;
using Shop.Infrastructure;
using Shop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.Products
{
    public class ProductAppService : ProductService
    {
        private ProductRepository _productRepository;
        private UnitOfWork _unitOfWork;
        public ProductAppService(ProductRepository productRepository, UnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddProductDto dto)
        {
            var record = _productRepository.Add(dto);
            _unitOfWork.Complete();
            return record.Id;
        }
        public List<GetProductDto> GetAll()
        {
            return _productRepository.GetAll();
        }
        public GetProductDto FindOneById(int id)
        {
            return _productRepository.FindOneById(id);
        }
        public void Update(int id, UpdateProductDto dto)
        {
            var res = _productRepository.Find(id);
            res.Code = dto.Code;
            res.MinimumAmount = dto.MinimumAmount;
            res.ProductCategoryId = dto.ProductCategoryId;
            res.Title = dto.Title;
            res.IsSufficientInStore = dto.IsSufficientInStore;
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
