using AngularETicaret.API.Dtos;
using AngularETicaret.Core.DBModels;
using AngularETicaret.Core.Interfaces;
using AngularETicaret.Core.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularETicaret.API.Controllers
{
 
    public class ProductsController : BaseApiController
    {
        //private readonly IProductRepository _productRepository;
        //public ProductsController(IProductRepository productRepository)
        //{

        //    _productRepository = productRepository;
        //}
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductsController(IMapper mapper, IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository)
        {
            _mapper = mapper;
            _productBrandRepository = productBrandRepository;
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort) //public async Task<IActionResult> GetProducts( ) bu şekildede yapılabilir
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(sort);//includelu hallerini gönderiyoruz
            var data = await _productRepository.ListAsync(spec);
            //data.Select(pro => new ProductToReturnDto {
            //    Id = pro.Id,
            //    Name = pro.Name,
            //    Description = pro.Description,
            //    PictureUrl = pro.PictureUrl,
            //    Price = pro.Price,
            //    ProductBrand = pro.ProductBrand != null ? pro.ProductBrand.Name : string.Empty,
            //    ProductType = pro.ProductType != null ? pro.ProductType.Name : string.Empty,

            //}).ToList();

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {

            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);//includelu hallerini gönderiyoruz
            var product = await _productRepository.GetEntityWithSpec(spec);
            //return new ProductToReturnDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand!=null ?product.ProductBrand.Name:string.Empty,
            //    ProductType = product.ProductType != null ? product.ProductType.Name : string.Empty,

            //};


            return _mapper.Map<Product, ProductToReturnDto>(product);
            //  return await _productRepository.GetEntityWithSpec (spec);
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
