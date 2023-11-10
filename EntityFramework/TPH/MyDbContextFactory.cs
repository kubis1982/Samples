namespace EntityFramework.TPH {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext> {
        public MyDbContext CreateDbContext(string[] args) {
            DbContextOptionsBuilder<MyDbContext> dbContextOptions = new();
            dbContextOptions.UseSqlite("Database.db");
            return new MyDbContext(dbContextOptions.Options);
        }
    }
}
