using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions.product;
using Services.Abstractions;
using Services.Specifications;
using shared;

namespace Services
{
    public class ProductService(IUnitOfWork uniteOfWork, IMapper Mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var Brand = await uniteOfWork.GetRepo<productBrand, int>().GetAllAsync();
            var BrandResult = Mapper.Map<IEnumerable<BrandResultDto>>(Brand);
            return BrandResult;
        }

        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
        {

            var products = await uniteOfWork.GetRepo<Product, int>().GetAllWithSpecificationAsync(new ProductWithBrandAndProductSpecification());
            var productsResult = Mapper.Map<IEnumerable<ProductResultDto>>(products);
            return productsResult;
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var Types = await uniteOfWork.GetRepo<productType, int>().GetAllAsync();
            var typeResult = Mapper.Map<IEnumerable<TypeResultDto>>(Types);
            return typeResult;
        }

        public async Task<ProductResultDto?> GetProductByIdAsync(int id)
        {
            var products = await uniteOfWork.GetRepo<Product, int>()
                .GetByIdlWithSpecificationAsync(new ProductWithBrandAndProductSpecification(id));
            return products is null ? throw new productNotFoundException(id):  Mapper.Map<ProductResultDto>(products);
            
        }
    }
}
