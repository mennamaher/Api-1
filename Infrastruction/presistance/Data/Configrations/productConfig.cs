using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace presistance.Data.Configrations
{
    internal class productConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region product

            builder.Property(Product => Product.price)
                .HasColumnType("decimal(18,3)");
            #endregion

            #region productBrand
            builder.HasOne(product => product.productBrand)
                .WithMany()
                .HasForeignKey(Product => Product.productBrand);
            #endregion

            #region productType

            builder.HasOne(product => product.productType)
                .WithMany()
                .HasForeignKey(Product => Product.TypedId);
            #endregion
        }
    }
}
