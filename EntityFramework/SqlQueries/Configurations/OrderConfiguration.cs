namespace EntityFramework.SqlQueries.Configurations {
    using EntityFramework.SqlQueries.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.HasKey(n => n.Id);
            builder.HasMany(n => n.Items).WithOne(n => n.Order);

            builder.HasData(new Order { ContractorId = 1, Id = 1 });
            builder.HasData(new Order { ContractorId = 2, Id = 2 });
            builder.HasData(new Order { ContractorId = 3, Id = 3 });
            builder.HasData(new Order { ContractorId = 4, Id = 4 });
        }
    }
}
