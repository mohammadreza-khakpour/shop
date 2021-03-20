using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        int Add(Product product);
        void Delete(int id);
        Product Find(int id);
        GetProductDto FindOneById(int id);
        List<GetProductDto> GetAll();
    }
}