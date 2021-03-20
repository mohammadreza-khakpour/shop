using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.ProductEntries.Contracts
{
    public interface ProductEntryRepository
    {
        int Add(ProductEntry productEntry);
        void Delete(int id);
        GetProductEntryDto FindOneById(int id);
        List<GetProductEntryDto> GetAll();
    }
}