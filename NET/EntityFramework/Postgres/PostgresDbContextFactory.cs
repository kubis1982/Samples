namespace EntityFramework.Postgres {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class PostgresDbContextFactory : IDesignTimeDbContextFactory<PostgresDbContext> {
        public PostgresDbContext CreateDbContext(string[] args) {
            DbContextOptionsBuilder<PostgresDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=mypassword;Host=localhost;Port=5432;Database=EFPostgres");
            dbContextOptionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));

            PostgresDbContext dbContext = new(dbContextOptionsBuilder.Options);
            return dbContext;
        }
    }
}
