using Shop.Entities;
using System.Collections.Generic;

namespace Shop.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentRepository
    {
        void Add(int checklistId);
        //void Delete(int id);
        //AccountingDocument Find(int id);
        GetAccountingDocumentDto FindOneById(int id);
        List<GetAccountingDocumentDto> GetAll();
    }
}