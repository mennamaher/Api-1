using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public string name {  get; set; }
        public string description { get; set; }
        public string PictureUrl { get; set; }
        public decimal price { get; set; }


        #region relation productBrand
        public int BrandId { get; set; }
        public productBrand productBrand { get; set; }

        #endregion

        #region relation productType
        public int TypedId { get; set; }
        public productType productType { get; set; }

        #endregion
    }
}
