namespace EntityFramework.Postgres.Configurations {
    using EntityFramework.Postgres.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TreeConfiguration : IEntityTypeConfiguration<Tree> {
        public void Configure(EntityTypeBuilder<Tree> builder) {
            builder.Property(n => n.Id);

            builder.Property(n => n.Code).HasMaxLength(40);

            builder.Property(n => n.LTree);

            builder.HasKey(n => n.Id);
        }
    }
}
