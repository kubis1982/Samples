namespace EntityFramework.Postgres {
    using Microsoft.EntityFrameworkCore;

    internal class PostgresTests {
        public void LTreeTest() {
            PostgresDbContextFactory dbContextFactory = new();
            var db = dbContextFactory.CreateDbContext([]);
            db.Database.EnsureDeleted();
            db.Database.Migrate();

            db.LTrees.Add(new Entities.Tree { Code = "Code", LTree = "Code" });
            db.LTrees.Add(new Entities.Tree { Code = "Code1", LTree = "Code.Code1" });
            db.LTrees.Add(new Entities.Tree { Code = "Code2", LTree = "Code.Code2" });
            db.LTrees.Add(new Entities.Tree { Code = "Code3", LTree = "Code.Code1.Code3" });

            db.SaveChanges();

            var models1 = db.LTrees.Where(n => n.LTree.IsAncestorOf("Code")).ToList();
            var models2 = db.LTrees.Where(n => n.LTree.IsDescendantOf("Code")).ToList();

            var models3 = db.LTrees.Where(n => n.LTree.IsDescendantOf("Code.Code1.Code3")).ToList();
            var models4 = db.LTrees.Where(n => n.LTree.IsAncestorOf("Code.Code1.Code3")).ToList();

        }
    }
}
