using Shop.Entities;
using Shop.Services.Products;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Exceptions;
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
        public void CheckForDuplicatedTitle(string title)
        {
            bool result = _dBContext.Products
                .Any(product => product.Title == title);
            if (result == true)
            {
                throw new ProductDuplicatedTitleException();
            }
        }
        public void CheckForDuplicatedCode(string code)
        {
            bool result = _dBContext.Products
                .Any(product => product.Code == code);
            if (result == true)
            {
                throw new ProductDuplicatedCodeException();
            }
        }
        public Product Add(AddProductDto dto)
        {
            CheckForDuplicatedTitle(dto.Title);
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

        public void UpdateSufficiencyStatus(int productId)
        {
            List<Warehouse> productWarehouses = 
                _dBContext.Warehouses.Where(x => x.ProductId == productId).ToList();
            int productOverallCount = 0;
            productWarehouses.ForEach(x => 
            {
                productOverallCount += x.ProductCount;
            });
            Product pro = _dBContext.Products.Find(productId);
            if (pro.MinimumAmount <= productOverallCount)
            {
                pro.IsSufficientInStore = false;
            }
            else
            {
                pro.IsSufficientInStore = true;
            }
        }
    }
}
