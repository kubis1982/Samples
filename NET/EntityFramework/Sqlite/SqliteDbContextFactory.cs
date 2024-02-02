namespace EntityFramework.Sqlite {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class SqliteDbContextFactory : IDesignTimeDbContextFactory<SqliteDbContext> {
        public SqliteDbContext CreateDbContext(string[] args) {
            DbContextOptionsBuilder<SqliteDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlite("Data Source=mydb.db");
            dbContextOptionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));
            SqliteDbContext dbContext = new(dbContextOptionsBuilder.Options);
            return dbContext;
        }
    }
}
