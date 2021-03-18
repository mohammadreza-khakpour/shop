using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCategoryRepository
    {
        private EFDataContext _dBContext;
        public EFProductCategoryRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int Add(ProductCategory category)
        {
            var result = _dBContext.ProductCategories.Add(category);
            return result.Entity.Id;
        }
        public List<GetProductCategoryDto> GetAll()
        {
            return _dBContext.ProductCategories.Select(_ => new GetProductCategoryDto
            {
                Id = _.Id,
                Title = _.Title
            }).ToList();
        }

        public GetProductCategoryDto FindOneById(int id)
        {
            var result = _dBContext.ProductCategories.Find(id);
            return new GetProductCategoryDto() { Id = result.Id, Title = result.Title };
        }

    }
}
