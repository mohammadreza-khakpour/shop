using Shop.Services.ProductCategories.Contracts;
using System.Collections.Generic;

namespace Shop.Services.ProductCategories
{
    public interface ProductCategoryService
    {
        int Add(AddProductCategoryDto dto);
        GetProductCategoryDto FindOneById(int id);
        List<GetProductCategoryDto> GetAll();
    }
}