namespace EntityFramework.SqlQueries.Configurations {
    using EntityFramework.SqlQueries.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem> {
        public void Configure(EntityTypeBuilder<OrderItem> builder) {
            builder.HasKey(n => n.Id);

            builder.HasData(new { ArticleId = 1, Id = 1, OrderId = 1 });
            builder.HasData(new { ArticleId = 2, Id = 2, OrderId = 1 });
            builder.HasData(new { ArticleId = 3, Id = 3, OrderId = 1 });
            builder.HasData(new { ArticleId = 4, Id = 4, OrderId = 1 });

            builder.HasData(new { ArticleId = 1, Id = 5, OrderId = 2 });
            builder.HasData(new { ArticleId = 2, Id = 6, OrderId = 2 });
            builder.HasData(new { ArticleId = 3, Id = 7, OrderId = 2 });
            builder.HasData(new { ArticleId = 4, Id = 8, OrderId = 2 });

            builder.HasData(new { ArticleId = 1, Id = 9, OrderId = 3 });
            builder.HasData(new { ArticleId = 2, Id = 10, OrderId = 3 });
            builder.HasData(new { ArticleId = 3, Id = 11, OrderId = 3 });
            builder.HasData(new { ArticleId = 4, Id = 12, OrderId = 3 });

            builder.HasData(new { ArticleId = 1, Id = 13, OrderId = 4 });
            builder.HasData(new { ArticleId = 2, Id = 14, OrderId = 4 });
            builder.HasData(new { ArticleId = 3, Id = 15, OrderId = 4 });
            builder.HasData(new { ArticleId = 4, Id = 16, OrderId = 4 });
        }
    }
}
