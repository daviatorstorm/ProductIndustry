using Microsoft.AspNetCore.Mvc;
using SIENN.Dto;
using SIENN.Services;
using System;

namespace SIENN.WebApi.Controllers
{
    public class ProductCategoryController : SiennController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productCategoryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productCategoryService.Get(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductCategoryDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return BadRequest(ModelState);
            }
            
            return Ok(_productCategoryService.Add(entity));
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
            _productCategoryService.Remove(id);

            return Ok();
        }
    }
}
