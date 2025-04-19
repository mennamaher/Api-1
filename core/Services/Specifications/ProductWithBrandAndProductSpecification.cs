using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Services.Specifications
{
    public class ProductWithBrandAndProductSpecification:Specifications<Product>
    {
        public ProductWithBrandAndProductSpecification(int id)
            :base(Product=>Product.Id==id) {
            AddInclude(Product => Product.productBrand);
            AddInclude(Product => Product.productType);

            #region pagination
            //ApplyPaginaton()
            #endregion
        }
        public ProductWithBrandAndProductSpecification()
          : base(null)
        {
            AddInclude(Product => Product.productBrand);
            AddInclude(Product => Product.productType);



        }

    }
}
