using Shop.Entities;
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
        public int Add(SalesCheckList salesCheckList)
        {
            var result = _dBContext.SalesCheckLists.Add(salesCheckList);
            return result.Entity.Id;
        }
        public void Delete(SalesCheckList salesCheckList)
        {
            _dBContext.SalesCheckLists.Remove(salesCheckList);
        }
        public List<GetSalesCheckListDto> GetAll()
        {
            return _dBContext.SalesCheckLists.Select(_ => new GetSalesCheckListDto
            {
                Id = _.Id,
                RecordDate = _.RecordDate,
                SerialNumber = _.SerialNumber
            }).ToList();
        }
        public GetSalesCheckListDto FindOneById(int id)
        {
            var result = _dBContext.SalesCheckLists.Find(id);
            return new GetSalesCheckListDto
            {
                Id = result.Id,
                RecordDate = result.RecordDate,
                SerialNumber = result.SerialNumber
            };
        }
    }
}
