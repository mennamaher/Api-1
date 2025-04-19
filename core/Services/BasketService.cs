using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities.Basket;
using Domain.Exceptions;
using Services.Abstractions;
using shared;

namespace Services
{
    public class BasketService(IBasketRepo basketRepo, IMapper Mapper) : IBasketService
    {
        public async Task<bool> DeleteBasketAsync(string id)
            => await basketRepo.DeleteBasketAsync(id);

        public async Task<BasketDto?> GetBasketAsync(string id)
        {
            var basket = await basketRepo.GetBasketAsync(id);
            return basket is null ? throw new BasketNotFoundException(id) : Mapper.Map<BasketDto>(basket);
        }

        public async Task<BasketDto?> UpdateBasketAsync(BasketDto basket)
        {
            var CustomerBasket = Mapper.Map<CustomerBasket>(basketRepo);
            var UpdatedBasket = await basketRepo.updateBasketAsync(CustomerBasket);
            return UpdatedBasket is null ?
                throw new Exception(" we cant update basket") :
                Mapper.Map<BasketDto>(UpdateBasketAsync);

        }
    }
}
