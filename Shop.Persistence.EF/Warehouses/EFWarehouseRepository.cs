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
        //public void Delete(int id)
        //{
        //    Warehouse theWarehouse = Find(id);
        //    _dbContext.Warehouses.Remove(theWarehouse);
        //}
        public List<GetWarehousesGroupedByProductIdDto> GetAll()
        {
            return GetWarehousesGroupedByProductId();
        }

        private List<GetWarehousesGroupedByProductIdDto> GetWarehousesGroupedByProductId()
        {

            var innerJoinQuery =
            from product in _dbContext.Products
            join warehouse in _dbContext.Warehouses on product.Id equals warehouse.ProductId
            select new 
            {
                product_id = product.Id,
                product_code = product.Code,
                product_title = product.Title,
                product_category_Id = product.ProductCategoryId,
                productCount_Overall = warehouse.ProductCount,
                product_minimumAmount = product.MinimumAmount,
                product_isEnough = product.IsSufficientInStore
            };


            var res001 = innerJoinQuery.ToList();
            var res002 = res001.GroupBy(x => x.product_id).Select(y => new GetWarehousesGroupedByProductIdDto
            {
                product_id = y.Key,
                product_code = y.First().product_code,
                product_title = y.First().product_title,
                product_category_Id = y.First().product_category_Id,
                productCount_Overall = y.Sum(z=>z.productCount_Overall),
                product_isEnough = y.First().product_isEnough,
                product_minimumAmount = y.First().product_minimumAmount

            }).ToList();
            return res002;
        }

        //public GetWarehouseDto FindOneById(int id)
        //{
        //    var result = _dbContext.Warehouses.Find(id);
        //    return new GetWarehouseDto
        //    {
        //        Id = result.Id,
        //        ProductCount = result.ProductCount,
        //        ProductId = result.ProductId,
        //    };
        //}

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
            if (pro.MinimumAmount <= sum)
            {
                pro.IsSufficientInStore = true;
            }
            else {
                pro.IsSufficientInStore = false;
            }
        }

        private Warehouse FindWarehouseWithProperAmount(int AtleastAmount,int productId)
        {
            try
            {
                var result = _dbContext.Warehouses.First(
                x => x.ProductId == productId && x.ProductCount >= Math.Abs(AtleastAmount));
                return result;
            }
            catch 
            {
                Warehouse firstWarehouse = FindTheFirstWarehouse(productId);
                int productCountOfFirstWarehouse = firstWarehouse.ProductCount;
                AtleastAmount = AtleastAmount + productCountOfFirstWarehouse;
                var result = _dbContext.Warehouses.First(
                x => x.ProductId == productId && x.ProductCount >= Math.Abs(AtleastAmount));
                return result;
            }
            
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
