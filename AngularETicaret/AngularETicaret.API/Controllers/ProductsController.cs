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
        //private readonly IProductRepository _productRepository;
        //public ProductsController(IProductRepository productRepository)
        //{

        //    _productRepository = productRepository;
        //}

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository)
        {
            _productBrandRepository = productBrandRepository;
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var data = await _productRepository.ListAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands() //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var data = await _productBrandRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes() //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var data = await _productTypeRepository.ListAllAsync();

            return Ok(data);
        }

    }
}
