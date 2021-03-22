using Shop.Entities;
using Shop.Services.Products;
using Shop.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private EFDataContext _dBContext;
        public EFProductRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Product Add(AddProductDto dto)
        {
            Product product = new Product
            {
                Code = dto.Code,
                MinimumAmount = dto.MinimumAmount,
                ProductCategoryId = dto.ProductCategoryId,
                Title = dto.Title,
            };
            var res = _dBContext.Products.Add(product);
            return res.Entity;
        }

        public void Delete(int id)
        {
            var res = Find(id);
            _dBContext.Products.Remove(res);
        }
        public Product Find(int id)
        {
            return _dBContext.Products.Find(id);
        }
        public List<GetProductDto> GetAll()
        {
            return _dBContext.Products.Select(_ => new GetProductDto
            {
                Id = _.Id,
                Title = _.Title,
                Code = _.Code,
                MinimumAmount = _.MinimumAmount,
                ProductCategoryId = _.ProductCategoryId,
                IsSufficientInStore = _.IsSufficientInStore
            }).ToList();
        }

        public GetProductDto FindOneById(int id)
        {
            var result = _dBContext.Products.Find(id);
            return new GetProductDto()
            {
                Id = result.Id,
                Title = result.Title,
                Code = result.Code,
                MinimumAmount = result.MinimumAmount,
                ProductCategoryId = result.ProductCategoryId,
                IsSufficientInStore = result.IsSufficientInStore
            };
        }
    }
}
