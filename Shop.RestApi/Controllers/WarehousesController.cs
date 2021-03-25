using Microsoft.AspNetCore.Mvc;
using Shop.Services.Warehouses;
using Shop.Services.Warehouses.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.RestApi.Controllers
{
    [ApiController]
    [Route("api/warehouse")]
    public class WarehousesController : Controller
    {
        private WarehouseService _service;
        public WarehousesController(WarehouseService service)
        {
            _service = service;
        }
        //[HttpPost]
        //public int Add([Required][FromBody] AddWarehouseDto dto)
        //{
        //    return _service.Add(dto);
        //}
        [HttpGet]
        public List<GetWarehouseDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetWarehouseDto FindOneById(int id)
        {
            return _service.FindOneById(id);
        }
        //[HttpPut("{id}")]
        //public void Update(int id, [FromBody] UpdateWarehouseDto dto)
        //{
        //    _service.Update(id, dto);
        //}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
