using Microsoft.AspNetCore.Mvc;
using Shop.Services.AccountingDocuments;
using Shop.Services.SalesCheckLists;
using Shop.Services.SalesCheckLists.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/sales-checklists")]
    public class SalesCheckListsController : Controller
    {
        
        private SalesCheckListService _service;
        private AccountingDocumentService _accountingService;
        public SalesCheckListsController(SalesCheckListService service, AccountingDocumentService accountingService)
        {
            _service = service;
            _accountingService = accountingService;
        }
        [HttpPost]
        public int Add([Required][FromBody] AddSalesCheckListDto dto)
        {
            _service.CheckIfProductsCountAreEnough(dto.SalesItems);
            int CheckListId =  _service.Add(dto);
            _accountingService.Add(CheckListId);
            return CheckListId;
        }
        [HttpGet]
        public List<GetSalesCheckListDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetOneSalesCheckListDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateSalesCheckListDto dto)
        {
            int CheckListId = _service.Update(id, dto);
            _accountingService.Add(CheckListId);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
