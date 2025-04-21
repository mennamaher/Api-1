using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class shippingAddress
    {
        public shippingAddress() { }
        public shippingAddress(string _fName, string _lName, string _country, string _city, string _street)
        {
            FName = _fName;
            LName = _lName;
            Country = _country;
            City = _city;
            street = _street;
        }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string street { get; set; }

    }
}
