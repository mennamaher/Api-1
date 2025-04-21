using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.OrderModule
{
    public record OrderResult
    {
        //public string BasketId { get; init; }
        //public ShippingAddressDto ShippingAddress { get; init; }
        //public int DeliveryMethodId { get; init; }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public ShippingAddressDto ShippingAdress { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public string paymentSatuts { get; set; }
        public int DeliveryMethod { get; set; }

        public decimal SubTotal { get; set; }
        public string PaymentIntentId { get; set; }=string.Empty;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public decimal total { get; set; }

    }
}
