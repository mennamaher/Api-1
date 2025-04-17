using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class productController(IServiceManager serviceManager) : ControllerBase
    {
        #region GetAllProducts

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProducts()
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync();
            return Ok(products);
        }

        #endregion

        #region get all brands

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
        {
            var brands = await serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }

        #endregion

        #region get all types

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
        {
            var types = await serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }

        #endregion

        #region get all productById

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetProductById(int id)
        {
            var Product = await serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(Product);
        }

        #endregion
    }
}
