namespace EntityFramework.TPH.Configurations {
    using EntityFramework.TPH.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderConfiguration : IEntityTypeConfiguration<Order<OrderId>> {
        public void Configure(EntityTypeBuilder<Order<OrderId>> builder) {
            builder.HasKey(n => n.Id);

           // builder.HasMany(n => n.Items).WithOne(n => n.Order);

            builder.HasDiscriminator<int>("OrderType")
                .HasValue<Order<OrderId>>(1)
                .HasValue<Order<OrderId>>(2);
        }
    }
}
