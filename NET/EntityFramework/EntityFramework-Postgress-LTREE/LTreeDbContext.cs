namespace EntityFramework_Postgress_LTREE {
    using Microsoft.EntityFrameworkCore;

    internal class LTreeDbContext(DbContextOptions<LTreeDbContext> dbContextOptions) : DbContext(dbContextOptions) {
        public virtual DbSet<LTreeModel> LTreeModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LTreeModel).Assembly);
        }
    }
}
