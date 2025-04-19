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
    public class BasketController(IServiceManager serviceManager) : ControllerBase
    {
        #region get
        [HttpGet("{id}")]

        public async Task<ActionResult<BasketDto>> GetBasket(string id)
        {
            var basket = await serviceManager.BasketService.GetBasketAsync(id);
            return Ok(basket);
        }
        #endregion

        #region update
        [HttpPost]

        public async Task<ActionResult<BasketDto>> updateBasket(BasketDto basketDto)
        {
            var basket = await serviceManager.BasketService.UpdateBasketAsync(basketDto);
            return Ok(basket);
        }
        #endregion

        #region delete
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteBasket(string id)
        {
            await serviceManager.BasketService.DeleteBasketAsync(id);
            return NoContent();
        }
        #endregion
    }
}
