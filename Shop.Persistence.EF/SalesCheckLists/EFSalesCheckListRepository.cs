using Shop.Entities;
using Shop.Services.SalesCheckLists;
using Shop.Services.SalesCheckLists.Contracts;
using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.SalesCheckLists
{
    public class EFSalesCheckListRepository : SalesCheckListRepository
    {
        private EFDataContext _dBContext;
        public EFSalesCheckListRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }
        public SalesCheckList Add(AddSalesCheckListDto dto)
        {
            SalesCheckList salesCheckList = new SalesCheckList
            {
                RecordDate = DateTime.Parse(dto.RecordDate),
                SerialNumber = dto.SerialNumber,
                CustomerFullName = dto.CustomerFullName,
            };
            var result = _dBContext.SalesCheckLists.Add(salesCheckList);
            return result.Entity;
        }
        public List<GetSalesCheckListDto> GetAll()
        {
            return _dBContext.SalesCheckLists.Select(_ => new GetSalesCheckListDto
            {
                Id = _.Id,
                RecordDate = _.RecordDate,
                SerialNumber = _.SerialNumber,
                CustomerFullName = _.CustomerFullName,
                OverAllProductCount = _.OverAllProductCount,
                OverAllProductPrice = _.OverAllProductPrice
            }).ToList();
        }
        public void Delete(int id)
        {
            var res = Find(id);
            _dBContext.SalesCheckLists.Remove(res);
        }
        
        public GetOneSalesCheckListDto FindOneById(int id)
        {
            var theSalesCheckList = _dBContext.SalesCheckLists.Find(id);
            var items = new List<GetSalesItemDto>();
            items = theSalesCheckList.Items.Select(x=>new GetSalesItemDto {
                Id = x.Id,
                ProductCode = x.ProductCode,
                ProductCount = x.ProductCount,
                ProductId = x.ProductId,
                ProductPrice = x.ProductPrice,
                SalesChecklistId = x.SalesChecklistId
            }).ToList();
            return new GetOneSalesCheckListDto
            {
                Id = theSalesCheckList.Id,
                RecordDate = theSalesCheckList.RecordDate,
                SerialNumber = theSalesCheckList.SerialNumber,
                CustomerFullName = theSalesCheckList.CustomerFullName,
                OverAllProductCount = theSalesCheckList.OverAllProductCount,
                OverAllProductPrice = theSalesCheckList.OverAllProductPrice,
                SalesItems = items
            };
        }
        public SalesCheckList Find(int id)
        {
            return _dBContext.SalesCheckLists.Find(id);
        }

        public SalesCheckList FindAndRemoveSalesItems(int id)
        {
            var salesChecklist = Find(id);
            salesChecklist.Items.Clear();
            //salesChecklist.Items ;
            salesChecklist.OverAllProductPrice = 0;
            salesChecklist.OverAllProductCount = 0;
            return salesChecklist;
        }
    }
}
