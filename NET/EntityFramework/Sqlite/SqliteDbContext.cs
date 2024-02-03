namespace EntityFramework.Sqlite {
    using EntityFramework.Sqlite.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class SqliteDbContext(DbContextOptions<SqliteDbContext> dbContextOptions) : DbContext(dbContextOptions) {
        public virtual DbSet<ExampleData> ExampleDatas { get; set; }
        public virtual DbSet<ExampleItemData> ExampleItemDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), n => n.Namespace?.Contains("Sqlite") == true);

            var example1Data = new ExampleData { Id = 1, Name = "Nazwa1" };
            modelBuilder.Entity<ExampleData>().HasData(example1Data);

            var example1Item = new { Id = 1, Name = "Nazwa1", ExampleId = example1Data.Id };
            modelBuilder.Entity<ExampleItemData>().HasData(example1Item);

            var example2Data = new ExampleData { Id = 2, Name = "Nazwa2" };
            modelBuilder.Entity<ExampleData>().HasData(example2Data);

            var example3Data = new ExampleData { Id = 3, Name = "Nazwa3" };
            modelBuilder.Entity<ExampleData>().HasData(example3Data);

            var example4Data = new ExampleData { Id = 4, Name = "Nazwa4" };
            modelBuilder.Entity<ExampleData>().HasData(example4Data);

            var example4Item = new { Id = 2, Name = "Nazwa4", ExampleId = example4Data.Id };
            modelBuilder.Entity<ExampleItemData>().HasData(example4Item);
        }
    }
}
