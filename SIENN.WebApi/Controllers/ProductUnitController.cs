using Microsoft.AspNetCore.Mvc;
using SIENN.Dto;
using SIENN.Services;
using System;

namespace SIENN.WebApi.Controllers
{
    public class ProductUnitController : SiennController
    {
        private readonly IProductUnitService _productUnitService;

        public ProductUnitController(IProductUnitService productUnitService)
        {
            _productUnitService = productUnitService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productUnitService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productUnitService.Get(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductUnitDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return BadRequest(ModelState);
            }

            return Ok(_productUnitService.Add(entity));
        }

        [HttpPut]
        public IActionResult Update(ProductDto entity)
        {
            // Implement Update in repository

            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(Guid id)
        {
            _productUnitService.Remove(id);

            return Ok();
        }
    }
}
