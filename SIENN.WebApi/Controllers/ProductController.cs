using Microsoft.AspNetCore.Mvc;
using SIENN.Dto;
using SIENN.Services;
using System;

namespace SIENN.WebApi.Controllers
{
    public class ProductController : SiennController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("available")]
        public IActionResult GetAllAvailable()
        {
            return Ok(_productService.GetAllAvailable());
        }

        [HttpGet("filter")]
        public IActionResult GetFiltred(ProductFilter filter)
        {
            return Ok(_productService.GetFiltred(filter));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDto entity)
        {
            return Ok(_productService.Add(entity));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductDto entity)
        {
            return Ok(_productService.Update(entity));
        }

        [HttpDelete]
        public IActionResult Remove(Guid id)
        {
            _productService.Remove(id);

            return Ok();
        }
    }
}
