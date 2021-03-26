using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.ProductEntries.Contracts
{
    public interface ProductEntryRepository
    {
        ProductEntry Add(AddProductEntryDto dto);
        void Delete(int id);
        GetProductEntryDto FindOneById(int id);
        List<GetProductEntryDto> GetAll();
        ProductEntry Find(int id);
    }
}