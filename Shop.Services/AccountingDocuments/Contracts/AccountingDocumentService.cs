using Shop.Services.AccountingDocuments.Contracts;
using System.Collections.Generic;

namespace Shop.Services.AccountingDocuments
{
    public interface AccountingDocumentService
    {
        void Add(int checklistId);
        //void Delete(int id);
        GetAccountingDocumentDto FindOneById(int id);
        List<GetAccountingDocumentDto> GetAll();
        //void Update(int id, UpdateAccountingDocumentDto dto);
    }
}