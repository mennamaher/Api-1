using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class Order:BaseEntity<Guid>
    {
        public Order() { }

        public Order(string _userEmail, shippingAddress _shippingAddress, ICollection<OrderItem> _orderItems, 
            OrderPaymentStatus _paymentStatus, DeliveryMethod _deliveryMethod,
            decimal _subTotal, string _paymentInId, DateTimeOffset _orderDate)
        {
            userEmail = _userEmail;
            shippingAddress = _shippingAddress;
            OrderItems = _orderItems;
            PaymentStatus = _paymentStatus;
            //DeliveryMethodId = _deliveryMethodId;
           deliveryMethod = _deliveryMethod;
            SubTotal = _subTotal;
            //PaymentInId = paymentInId;
            //OrderDate = orderDate;
        }

        public string userEmail { get; set; }

        public shippingAddress shippingAddress { get; set; }
        public ICollection <OrderItem> OrderItems { get; set; }
        public OrderPaymentStatus PaymentStatus { get; set; }

        public int? DeliveryMethodId { get; set; }
        public DeliveryMethod deliveryMethod { get; set; }

        public decimal SubTotal { get; set; }
        public string PaymentInId { get; set; }= string .Empty;
        public DateTimeOffset OrderDate { get; set; }=DateTimeOffset.Now;

    }
}
