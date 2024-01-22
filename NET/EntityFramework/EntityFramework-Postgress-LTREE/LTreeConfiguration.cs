namespace EntityFramework_Postgress_LTREE {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class LTreeConfiguration : IEntityTypeConfiguration<LTreeModel> {
        public void Configure(EntityTypeBuilder<LTreeModel> builder) {
            builder.Property(n => n.Id);

            builder.Property(n => n.Code).HasMaxLength(40);

            builder.Property(n => n.LTree);

            builder.HasKey(n => n.Id);
        }
    }
}
