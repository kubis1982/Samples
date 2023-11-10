namespace EntityFramework.TPH {
    using EntityFramework.TPH.Configurations;
    using EntityFramework.TPH.Entities;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext {
        public MyDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
           // modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}
