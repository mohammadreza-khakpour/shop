using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void CheckForDuplicatedTitle(string title);
        Product Add(AddProductDto dto);
        void Delete(int id);
        Product Find(int id);
        GetProductDto FindOneById(int id);
        List<GetProductDto> GetAll();
    }
}