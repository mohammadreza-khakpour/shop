using Microsoft.AspNetCore.Mvc;
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
        public SalesCheckListsController(SalesCheckListService service)
        {
            _service = service;
        }
        [HttpPost]
        public int Add([Required][FromBody] AddSalesCheckListDto dto)
        {
            return _service.Add(dto);
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
            _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
