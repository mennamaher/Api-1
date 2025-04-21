using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.OrderEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace presistance.Data.Configrations.Order
{
    public class OrderConfigrations : IEntityTypeConfiguration<Domain.Entities.OrderEntity.Order>
    {
     
        public void Configure(EntityTypeBuilder<Domain.Entities.OrderEntity.Order> builder)
        {
            #region address
            builder.OwnsOne(p => p.shippingAddress, p => p.WithOwner());
            #endregion

            #region orderitems
            builder.HasMany(o =>o.OrderItems)
                .WithOne();
            #endregion

            #region payment
            builder.Property(p=>p.PaymentStatus)
                .HasConversion(s=>s.ToString()
                , s => Enum.Parse<OrderPaymentStatus> (s));
            #endregion

            #region delivery

            builder.HasOne(p => p.deliveryMethod)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

            #region subtotal
            builder.Property(p =>p.SubTotal )
                .HasColumnType("decimal(18m3)");
            #endregion
        }
    }
}
