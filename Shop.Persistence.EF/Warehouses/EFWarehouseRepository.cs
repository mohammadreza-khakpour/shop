using Shop.Entities;
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
        public void Delete(Warehouse warehouse)
        {
            _dbContext.Warehouses.Remove(warehouse);
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
    }
}
