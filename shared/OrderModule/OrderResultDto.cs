using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.OrderModule
{
    public record OrderResultDto
    {
        public Guid Id { get; set; }
        public string UserName { get; init; }
        public ShippingAddressDto ShippingAdress { get; init; }
        public ICollection<OrderItemDto> OrderItems { get; init; }=new List<OrderItemDto>();
        public string paymentSatuts {  get; init; }
        public int DeliveryMethod { get; init; }

        public decimal SubTotal     { get; init; }
        public DateTimeOffset OrderDate { get; init; }=DateTimeOffset.Now;
        public decimal total { get; init; }


    }
}
