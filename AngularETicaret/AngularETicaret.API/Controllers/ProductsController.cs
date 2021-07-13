using AngularETicaret.Core.DBModels;
using AngularETicaret.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var data = await _productRepository.GetProductAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands() //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var data = await _productRepository.GetProductBrandsAsync();
            return Ok(data);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> GetProductTypes() //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var data = await _productRepository.GetProductTypesAsync();
            return Ok(data);
        }

    }
}
