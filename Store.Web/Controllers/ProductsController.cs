﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.ProductServices;
using Store.Service.Services.ProductServices.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>>GetAllBrands()
            =>Ok(await productService.GetAllBrandsAsync());


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
    => Ok(await productService.GetAllTypesAsync());


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts()
    => Ok(await productService.GetAllProductsAsync());


        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int? id)
    => Ok(await productService.GetProductByIdAsync(id));
    }
}
