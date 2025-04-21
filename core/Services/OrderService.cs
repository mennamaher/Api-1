using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.OrderEntity;
using Domain.Exceptions.product;
using Services.Abstractions;
using shared.OrderModule;

namespace Services
{
    public class OrderService(IMapper mapper, IBasketRepo basketRepo, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<OrderResultDto> CreateOrderAsync(OrderResult orderRequest, string userEmail)
        {
            var shippingAddress = mapper.Map<shippingAddress>(orderRequest.ShippingAdress);
            var Basket = await basketRepo.GetBasketAsync(orderRequest.BasketId)
                ?? throw new BasketNotFoundException(orderRequest.BasketId); 
            var orderItem = new List<OrderItem>();
            foreach (var item in Basket.Item) {
                var product = await unitOfWork.GetRepo<Product, int>()
                    .GetByIdAsync(item.Id)?? throw new productNotFoundException(item.id);

                orderItem.Add(createOrderItem(item,product));
            }
        }

        private OrderItem createOrderItem(object item, object product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderResultDto>> GetOrderByEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResultDto> GetOrderByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
