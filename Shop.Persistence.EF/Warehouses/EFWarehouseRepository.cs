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
        public int Add(int productCount, int productId)
        {
            Warehouse wr = new Warehouse
            {
                ProductCount = productCount,
                ProductId = productId
            };
            var result = _dbContext.Warehouses.Add(wr);
            return result.Entity.Id;
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

        public void CheckIfProductAmountIsSufficient(int productId)
        {
            Product pro = _dbContext.Products.Find(productId);
            List<Warehouse> Warehouses = _dbContext.Warehouses.Where(x => x.ProductId==productId).ToList();
            int sum = 0;

            Warehouses.ForEach(x=> 
            {
                sum += x.ProductCount;
            });
            if (pro.MinimumAmount < sum)
            {
                pro.IsSufficientInStore = false;
            }
            else {
                pro.IsSufficientInStore = true;
            }
        }

        private Warehouse FindWarehouseWithProperAmount(int AtleastAmount,int productId)
        {
            return _dbContext.Warehouses.First(
                x => x.ProductId==productId && x.ProductCount >= Math.Abs(AtleastAmount));
        }

        private Warehouse FindTheFirstWarehouse(int productId)
        {
            return _dbContext.Warehouses.First(x => x.ProductId == productId);
        }

        public void ManageWarehousesAgain(int countDiffer,int productId)
        {
            if (countDiffer < 0)
            {
                Warehouse warehouse = FindWarehouseWithProperAmount(countDiffer,productId);
                warehouse.ProductCount += countDiffer;
            }
            if (countDiffer > 0)
            {
                Warehouse warehouse = FindTheFirstWarehouse(productId);
                warehouse.ProductCount += countDiffer;
            }
        }
    }
}
