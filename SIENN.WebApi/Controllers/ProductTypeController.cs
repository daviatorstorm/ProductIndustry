using Microsoft.AspNetCore.Mvc;
using SIENN.Dto;
using SIENN.Services;
using System;

namespace SIENN.WebApi.Controllers
{
    public class ProductTypeController : SiennController
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productTypeService.Get(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductTypeDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return BadRequest(ModelState);
            }

            return Ok(_productTypeService.Add(entity));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductTypeDto entity)
        {
            return Ok(_productTypeService.Update(entity));
        }

        [HttpDelete]
        public IActionResult Remove(Guid id)
        {
            _productTypeService.Remove(id);

            return Ok();
        }
    }
}
