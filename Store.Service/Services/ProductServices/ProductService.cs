using Store.Date.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntity = Store.Date.Entities.Product;
using Store.Service.Services.ProductServices;
using Store.Service.Services.ProductServices.Dtos;
using AutoMapper;


namespace Store.Services.ProductServices
{
    public class ProductService : IProductService { 
        private readonly IUnitOfwork unitOfwork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfwork unitOfwork,IMapper mapper)
        {
            this.unitOfwork = unitOfwork;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await unitOfwork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();
            var mappedBrands = mapper.Map < IReadOnlyList < BrandTypeDetailsDto >>(brands);
            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await unitOfwork.Repository<ProductEntity, int>().GetAllAsNoTrackingAsync();
            var mappedProducts = mapper.Map < IReadOnlyList < ProductDetailsDto >>(products);
            return mappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await unitOfwork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();
            var mappedTypes = mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId is null) throw new Exception("Id is Null");

            var products = await unitOfwork.Repository<ProductEntity, int>().GetByIdAsync(productId.Value);
            if (products == null) throw new Exception("Product Not Found");
            var mappedProduct = mapper.Map<ProductDetailsDto>(products);
            return mappedProduct;

        }
    }
}
