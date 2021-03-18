using Shop.Entities;
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

        public int Add(Product product)
        {
            var result = _dBContext.Products.Add(product);
            return result.Entity.Id;
        }

        public void Delete(Product product)
        {
            _dBContext.Products.Remove(product);
        }

        public List<GetProductDto> GetAll()
        {
            return _dBContext.Products.Select(_ => new GetProductDto
            {
                Id = _.Id,
                Title = _.Title,
                Code = _.Code,
                MinimumAmount = _.MinimumAmount,
                ProductCategoryId = _.ProductCategoryId
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
                ProductCategoryId = result.ProductCategoryId
            };
        }
    }
}
