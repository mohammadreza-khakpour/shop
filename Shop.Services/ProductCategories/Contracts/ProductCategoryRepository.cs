﻿using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        void CheckForDuplicatedTitle(string title);
        ProductCategory Add(AddProductCategoryDto dto);
        GetProductCategoryDto FindOneById(int id);
        List<GetProductCategoryDto> GetAll();
    }
}