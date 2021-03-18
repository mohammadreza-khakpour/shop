using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Persistence.EF.ProductEntries
{
    public interface productEntryRepository
    {
        int Add(ProductEntry productEntry);
        void Delete(ProductEntry productEntry);
        GetProductEntryDto FindOneById(int id);
        List<GetProductEntryDto> GetAll();
    }
}