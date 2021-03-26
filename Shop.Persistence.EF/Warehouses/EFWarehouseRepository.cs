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
        public List<RecordsWithSameProductIdInProducts> GetAll()
        {
            return GetRecordsWithSameProductIdInProducts();
        }

        public List<RecordsWithSameProductIdInProducts> GetRecordsWithSameProductIdInProducts()
        {
            var groupedByProductId = _dbContext.Warehouses.GroupBy(x => x.ProductId)
                   .Select(y => new 
                   { groupKey = y.Key, sumOfGroupElementsCount = y.Sum(z=>z.ProductCount) }).ToList();

            var innerJoinQuery =
            from product in _dbContext.Products
            join warehouse in _dbContext.Warehouses on product.Id equals warehouse.ProductId
            select new RecordsWithSameProductIdInProducts
            {
                product_id = product.Id,
                product_code = product.Code,
                product_title = product.Title,
                product_category_Id = product.ProductCategoryId,
                //productCount_Overall = groupedByProductId.Find(c=>c.groupKey==product.Id).sumOfGroupElementsCount,
                productCount_Overall = 0,
                product_minimumAmount = product.MinimumAmount,
                product_isEnough = product.IsSufficientInStore
            };
            var res = innerJoinQuery.ToList();
            res.ForEach(j => 
            {
                j.productCount_Overall =
                groupedByProductId.Find(c => c.groupKey == j.product_id).sumOfGroupElementsCount;
            });
            return res;
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

        // should be checked when selling, not here
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
            var result = _dbContext.Warehouses.First(
                x => x.ProductId==productId && x.ProductCount >= Math.Abs(AtleastAmount));
            return result;
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

        public void MinusDeletedAmount(int ProductId, int ProductCount)
        {
           Warehouse warehouse =  FindWarehouseWithProperAmount(ProductCount,ProductId);
            warehouse.ProductCount -= ProductCount;
        }
    }
}
