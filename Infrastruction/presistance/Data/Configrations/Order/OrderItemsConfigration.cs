using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.OrderEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace presistance.Data.Configrations.Order
{
    
        class OrderItemsConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(D => D.Price).HasColumnType("decimal(18,3)");
            builder.OwnsOne(d => d.Product, p => p.WithOwner());
        }
    }
}
