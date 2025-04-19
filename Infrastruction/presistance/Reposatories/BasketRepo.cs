using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities.Basket;
using StackExchange.Redis;

namespace presistance.Reposatories
{
    public class BasketRepo(IConnectionMultiplexer connectionMultiplexer) :
        IBasketRepo
    {
        private readonly IDatabase _database=connectionMultiplexer.GetDatabase();
        public async Task<bool> DeleteBasketAsync(string id)
          => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetBasket(string id)
        {
            var value = await _database.StringGetAsync(id);
            if(value.IsNullOrEmpty) return null;
            return JsonSerializer.Deserialize<CustomerBasket>(value);
        }

        public Task<CustomerBasket?> GetBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerBasket?> updateBasketAsync(CustomerBasket basket, TimeSpan? timeSpan = null)
        {
            var JsonBasket = JsonSerializer.Serialize(basket);
            var IsCreatedOrUpate = await _database.StringSetAsync(basket.Id, JsonBasket, timeSpan ?? TimeSpan.FromDays(30));
            return IsCreatedOrUpate ? await GetBasketAsync(basket.Id) : null;
        }
    }
}
