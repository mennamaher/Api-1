﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shared;

namespace Services.Abstractions
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();
        public Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();

        public Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();

        public Task<ProductResultDto?> GetProductByIdAsync(int Id);

    }
}
