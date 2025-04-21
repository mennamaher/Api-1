using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shared.OrderModule;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        public Task<OrderResultDto> GetOrderByIdAsync(Guid Id);

        public Task<IEnumerable<OrderResultDto>> GetOrderByEmailAsync(string Email);

        public Task<OrderResultDto> CreateOrderAsync(OrderResult orderRequest, string userEmail);

        public Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodAsync();

    }
}
