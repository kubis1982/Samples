namespace EntityFramework.Sqlite {
    using EntityFramework.Postgres.Entities;
    using EntityFramework.Sqlite.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class SqliteDbContext(DbContextOptions<SqliteDbContext> dbContextOptions) : DbContext(dbContextOptions) {
        public virtual DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), n => n.Namespace?.Contains("Sqlite") == true) ;
        }
    }
}
