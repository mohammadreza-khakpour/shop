using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        int Add(ProductCategory category);
        GetProductCategoryDto FindOneById(int id);
        List<GetProductCategoryDto> GetAll();
    }
}