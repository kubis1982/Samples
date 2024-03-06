namespace EntityFramework.Postgres {
    using Dapper;
    using EntityFramework.Postgres.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class DapperTests {
        [Fact]
        public async Task ShouldGetDynamic() {
            // Arrange
            PostgresDbContextFactory dbContextFactory = new();
            var db = dbContextFactory.CreateDbContext([]);
            db.Database.EnsureDeleted();
            db.Database.Migrate();
            db.LTrees.Add(new Tree { Id = 1, Code = null, LTree = "SDFS", Dt = DateTime.UtcNow });
            db.LTrees.Add(new Tree { Id = 2, Code = "SDFSF", LTree = "SDFS" });
            db.LTrees.Add(new Tree { Id = 3, Code = "SDFSF", LTree = "SDFS" });
            db.SaveChanges();
            var connection = db.Database.GetDbConnection();

            // Act
           var result = await connection.QueryAsync("""
SELECT * FROM "LTrees"
""");

            // Assert
            var item = (IDictionary<string, object>)result.First();

            item.Keys.Should().Contain(new string[] { "Id", "Code", "LTree", "Dt" });
            item.Values.Count.Should().Be(3);
        }

        [Fact]
        public async Task ShouldGetDynamicWithParameter() {
            // Arrange
            PostgresDbContextFactory dbContextFactory = new();
            var db = dbContextFactory.CreateDbContext([]);
            db.Database.EnsureDeleted();
            db.Database.Migrate();
            db.LTrees.Add(new Tree { Id = 1, Code = null, LTree = "SDFS", Dt = DateTime.UtcNow });
            db.SaveChanges();
            var connection = db.Database.GetDbConnection();

            // Act
            var result = await connection.QueryAsync("""
SELECT * FROM "LTrees"
WHERE "Id" = @Id
""", new Dictionary<string, object> { { "Id", 1 } });

            // Assert
            var item = (IDictionary<string, object>)result.First();

            item["Code"].Should().Be(null);
            item["LTree"].Should().Be("SDFS");
        }

    }
}
