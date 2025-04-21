using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class ProductInOrderItem
    {
        public ProductInOrderItem() { }
        public ProductInOrderItem(int _productId, string _productName, string _pictureurl)
        {
            ProductId = _productId;
            ProductName = _productName;
            Pictureurl = _pictureurl;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Pictureurl { get; set; }

    }
}
