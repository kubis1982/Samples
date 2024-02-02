namespace EntityFramework.Sqlite.Configurations {
    using EntityFramework.Sqlite.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ExampleDataConfiguration : IEntityTypeConfiguration<ExampleData> {
        public void Configure(EntityTypeBuilder<ExampleData> builder) {
            builder.Property(n => n.Id);

            builder.Property(n => n.Name).HasMaxLength(80);

            builder.HasKey(n => n.Id);
        }
    }
}
