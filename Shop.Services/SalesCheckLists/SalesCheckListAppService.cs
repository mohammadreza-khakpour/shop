using Shop.Entities;
using Shop.Infrastructure;
using Shop.Services.SalesCheckLists.Contracts;
using Shop.Services.SalesItems;
using Shop.Services.SalesItems.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services.SalesCheckLists
{
    public class SalesCheckListAppService : SalesCheckListService
    {
        private SalesCheckListRepository _salesCheckListRepository;
        private SalesItemRepository _salesItemRepository;
        private UnitOfWork _unitOfWork;
        public SalesCheckListAppService(
            SalesCheckListRepository salesCheckListRepository, 
            UnitOfWork unitOfWork, 
            SalesItemRepository salesItemRepository)
        {
            _salesCheckListRepository = salesCheckListRepository;
            _unitOfWork = unitOfWork;
            _salesItemRepository = salesItemRepository;
        }
        public int Add(AddSalesCheckListDto dto)
        {
            SalesCheckList salesCheckList = new SalesCheckList
            {
                RecordDate = DateTime.Parse(dto.RecordDate),
                SerialNumber = dto.SerialNumber,
                CustomerFullName = dto.CustomerFullName,
            };
            List<AddSalesItemDto> dtoSalesItems = dto.SalesItems;
            dtoSalesItems.ForEach(dtoSaleItem=> 
            {
                SalesItem addedSalesItem = _salesItemRepository.Add(dtoSaleItem);
                salesCheckList.Items.Add(addedSalesItem);
            });
            var record = _salesCheckListRepository.Add(salesCheckList);
            _unitOfWork.Complete();
            return record.Id;
        }
        public void Update(int id, UpdateSalesCheckListDto dto)
        {
            var res = _salesCheckListRepository.Find(id);
            res.RecordDate = dto.RecordDate;
            res.SerialNumber = dto.SerialNumber;
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            _salesCheckListRepository.Delete(id);
        }
        public List<GetSalesCheckListDto> GetAll()
        {
            return _salesCheckListRepository.GetAll();
        }
        public GetSalesCheckListDto FindOneById(int id)
        {
            return _salesCheckListRepository.FindOneById(id);
        }
    }
}
