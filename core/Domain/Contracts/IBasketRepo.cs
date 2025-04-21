using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Basket;

namespace Domain.Contracts
{
    public interface IBasketRepo
    {
        public Task<CustomerBasket?> GetBasketAsync(string id);
        public Task<CustomerBasket?> updateBasketAsync(CustomerBasket basket, TimeSpan? timeSpan=null);
        public Task<bool> DeleteBasketAsync(string id);
        Task GetBasketAsync(Guid id);
    }
}
