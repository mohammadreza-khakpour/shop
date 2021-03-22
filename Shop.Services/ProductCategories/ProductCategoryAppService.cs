using Shop.Entities;
using Shop.Infrastructure;
using Shop.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.ProductCategories
{
    public class ProductCategoryAppService : ProductCategoryService
    {
        private ProductCategoryRepository _productCategoryRepository;
        private UnitOfWork _unitOfWork;
        public ProductCategoryAppService
            (ProductCategoryRepository productCategoryRepository,
            UnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddProductCategoryDto dto)
        {
            var record = _productCategoryRepository.Add(dto);
            _unitOfWork.Complete();
            return record.Id;
        }
        public List<GetProductCategoryDto> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }
        public GetProductCategoryDto FindOneById(int id)
        {
            return _productCategoryRepository.FindOneById(id);
        }
    }
}
