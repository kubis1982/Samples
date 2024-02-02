namespace EntityFramework.Postgres {
    using EntityFramework.Postgres.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PostgresDbContext(DbContextOptions<PostgresDbContext> dbContextOptions) : DbContext(dbContextOptions) {
        public virtual DbSet<Tree> LTrees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Tree).Assembly, n => n.Namespace?.Contains("Postgres") == true) ;
        }
    }
}
