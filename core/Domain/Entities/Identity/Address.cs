using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }




    }
}
