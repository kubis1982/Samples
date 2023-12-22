namespace EntityFramework.SqlQueries {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext> {
        public MyDbContext CreateDbContext(params string[] args) {
            DbContextOptionsBuilder<MyDbContext> dbContextOptions = new();
            dbContextOptions.UseSqlite("Data Source=database.db");
            dbContextOptions.ConfigureWarnings(
               b => b.Log(
                   (RelationalEventId.TransactionCommitted, LogLevel.Information),
                   (RelationalEventId.TransactionStarted, LogLevel.Information),
                   (RelationalEventId.TransactionRolledBack, LogLevel.Information)));

#if DEBUG
            dbContextOptions.LogTo(s => System.Diagnostics.Debug.WriteLine(s), (eventId, logLevel) => logLevel >= LogLevel.Information
                                   || eventId == RelationalEventId.TransactionStarted
                                   || eventId == RelationalEventId.TransactionCommitted
                                   || eventId == RelationalEventId.TransactionRolledBack)
             .EnableDetailedErrors(true)
             .EnableSensitiveDataLogging(true);
#endif
            return new MyDbContext(dbContextOptions.Options);
        }
    }
}
