using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.ProductEntries
{
    public class EFproductEntryRepository : productEntryRepository
    {
        private EFDataContext _dBContext;
        public EFproductEntryRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int Add(ProductEntry productEntry)
        {
            var result = _dBContext.ProductEntries.Add(productEntry);
            return result.Entity.Id;
        }

        public void Delete(ProductEntry productEntry)
        {
            _dBContext.ProductEntries.Remove(productEntry);
        }

        public List<GetProductEntryDto> GetAll()
        {
            return _dBContext.ProductEntries.Select(_ => new GetProductEntryDto
            {
                Id = _.Id,
                EntryDate = _.EntryDate,
                EntrySerialNumber = _.EntrySerialNumber,
                ProductCount = _.ProductCount,
                ProductId = _.ProductId
            }).ToList();
        }

        public GetProductEntryDto FindOneById(int id)
        {
            var result = _dBContext.ProductEntries.Find(id);
            return new GetProductEntryDto()
            {
                Id = result.Id,
                EntryDate = result.EntryDate,
                EntrySerialNumber = result.EntrySerialNumber,
                ProductCount = result.ProductCount,
                ProductId = result.ProductId
            };
        }

    }

}
