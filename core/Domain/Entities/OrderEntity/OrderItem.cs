using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class OrderItem:BaseEntity<Guid>
    {
        public OrderItem() { }
        public OrderItem(ProductInOrderItem _product, int _quantity, decimal _price)
        {
            Product = _product;
            Quantity = _quantity;
            Price = _price;
        }

        public ProductInOrderItem Product {  get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
