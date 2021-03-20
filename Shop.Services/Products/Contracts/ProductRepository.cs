using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Persistence.EF.Products
{
    public interface ProductRepository
    {
        int Add(Product product);
        void Delete(Product product);
        GetProductDto FindOneById(int id);
        List<GetProductDto> GetAll();
    }
}