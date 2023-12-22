namespace EntityFramework.SqlQueries {
    using EntityFramework.SqlQueries.Entities;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext(DbContextOptions options) : DbContext(options) {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        }

        protected sealed override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder
                .Properties<DateTime>()
                .HavePrecision(2);

            configurationBuilder
                .Properties<decimal>()
                .HavePrecision(14, 4);

            configurationBuilder
               .Properties<string>()
               .HaveMaxLength(50);
        }
    }
}
