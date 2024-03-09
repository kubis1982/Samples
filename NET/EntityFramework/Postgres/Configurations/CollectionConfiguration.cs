namespace EntityFramework.Postgres.Configurations {
    using EntityFramework.Postgres.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CollectionConfiguration : IEntityTypeConfiguration<Collection> {
        public void Configure(EntityTypeBuilder<Collection> builder) {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.AggregateTypes).HasConversion(builder => string.Join(',', builder), reader => reader.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
