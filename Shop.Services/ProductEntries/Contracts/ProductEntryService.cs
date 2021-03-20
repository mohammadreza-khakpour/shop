using Shop.Services.ProductEntries.Contracts;
using System.Collections.Generic;

namespace Shop.Services.ProductEntries
{
    public interface ProductEntryService
    {
        int Add(AddProductEntryDto dto);
        void Delete(int id);
        GetProductEntryDto FindOneById(int id);
        List<GetProductEntryDto> GetAll();
        void Update(int id, UpdateProductEntryDto dto);
    }
}