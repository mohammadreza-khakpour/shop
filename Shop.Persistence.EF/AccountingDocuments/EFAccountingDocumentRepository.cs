using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Persistence.EF.AccountingDocuments
{
    public class EFAccountingDocumentRepository
    {
        private EFDataContext _dBContext;
        public EFAccountingDocumentRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }

        public int Add(AccountingDocument accountingDocument)
        {
            var result = _dBContext.AccountingDocuments.Add(accountingDocument);
            return result.Entity.Id;
        }

        public void Delete(AccountingDocument accountingDocument)
        {
            _dBContext.AccountingDocuments.Remove(accountingDocument);
        }

        public List<GetAccountingDocumentDto> GetAll()
        {
            return _dBContext.AccountingDocuments.Select(_ => new GetAccountingDocumentDto
            {
                Id = _.Id,
                CreationDate = _.CreationDate,
                SalesCheckListId = _.SalesCheckListId,
                SerialNumber = _.SerialNumber
            }).ToList();
        }

        public GetAccountingDocumentDto FindOneById(int id)
        {
            var result = _dBContext.AccountingDocuments.Find(id);
            return new GetAccountingDocumentDto()
            {
                Id = result.Id,
                CreationDate = result.CreationDate,
                SalesCheckListId = result.SalesCheckListId,
                SerialNumber = result.SerialNumber
            };
        }
    }
}
