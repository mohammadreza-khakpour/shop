using Shop.Services.Products.Contracts;
using System.Collections.Generic;

namespace Shop.Services.Products
{
    public interface ProductService
    {
        int Add(AddProductDto dto);
        void Delete(int id);
        GetProductDto FindOneById(int id);
        List<GetProductDto> GetAll();
        void Update(int id, UpdateProductDto dto);
        void UpdateSufficiencyStatus(int productId);
    }
}