using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Persistence.EF.ProductCategories
{
    public interface ProductCategoryRepository
    {
        int Add(ProductCategory category);
        GetProductCategoryDto FindOneById(int id);
        List<GetProductCategoryDto> GetAll();
    }
}