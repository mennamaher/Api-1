using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared
{
    public record ProductResultDto
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string PictureUrl { get; set; }
        public decimal price { get; set; }

      
        public string BrandName { get; set; }

        public string TypeName { get; set; }



        
    }
}
