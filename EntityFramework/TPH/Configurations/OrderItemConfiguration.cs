//namespace EntityFramework.TPH.Configurations {
//    using EntityFramework.TPH.Entities;
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;
//    using System;

//    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem> {
//        public void Configure(EntityTypeBuilder<OrderItem> builder) {
//            builder.HasKey(n => n.Id);

//            builder.HasDiscriminator<int>("OrderType")
//                .HasValue<PurchaseOrderItem>(1)
//                .HasValue<SaleOrderItem>(2);
//        }
//    }
//}
