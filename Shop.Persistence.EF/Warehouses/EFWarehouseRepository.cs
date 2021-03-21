using Shop.Entities;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.Warehouses
{
    public class EFWarehouseRepository : WarehouseRepository
    {
        private EFDataContext _dbContext;
        public EFWarehouseRepository(EFDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Warehouse warehouse)
        {
            return _dbContext.Warehouses.Add(warehouse).Entity.Id;
        }
        public void Delete(int id)
        {
            Warehouse theWarehouse = Find(id);
            _dbContext.Warehouses.Remove(theWarehouse);
        }
        public List<GetWarehouseDto> GetAll()
        {
            return _dbContext.Warehouses.Select(_ => new GetWarehouseDto
            {
                Id = _.Id,
                ProductCount = _.ProductCount,
                ProductId = _.ProductId,
            }).ToList();
        }
        public GetWarehouseDto FindOneById(int id)
        {
            var result = _dbContext.Warehouses.Find(id);
            return new GetWarehouseDto
            {
                Id = result.Id,
                ProductCount = result.ProductCount,
                ProductId = result.ProductId,
            };
        }

        public Warehouse Find(int id)
        {
            return _dbContext.Warehouses.Find(id);
        }
    }
}
