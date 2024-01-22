namespace EntityFramework_Postgress_LTREE {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    internal class LTreeDbContextFactory : IDesignTimeDbContextFactory<LTreeDbContext> {
        public LTreeDbContext CreateDbContext(string[] args) {
            DbContextOptionsBuilder<LTreeDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=mypassword;Host=localhost;Port=5432;Database=LTREE");
            dbContextOptionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));

            LTreeDbContext dbContext = new(dbContextOptionsBuilder.Options);
            return dbContext;
        }
    }
}
