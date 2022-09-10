using Microsoft.AspNetCore.Mvc;
using SalesCatalog.Application.DTOs;
using SalesCatalog.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace SalesCatalog.API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("products")]
        public async Task Post([FromBody] ProductDTO productDto)
        {
            await _productService.Add(productDto);
        }

        [HttpPut("products")]
        public async Task Put([FromBody] ProductDTO productDto)
        {
            await _productService.Update(productDto);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetById([FromBody] Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _productService.GetProducts());
        }
    }
}
