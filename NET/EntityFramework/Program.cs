// See https://aka.ms/new-console-template for more information

using EntityFramework.Postgres;
using Microsoft.EntityFrameworkCore;

PostgresDbContextFactory dbContextFactory = new();
var db = dbContextFactory.CreateDbContext(args);

db.Database.EnsureDeleted();

db.Database.Migrate();

//db.LTrees.Add(new LTreeModel { Code = "Code", LTree = "Code" });
//db.LTrees.Add(new LTreeModel { Code = "Code1", LTree = "Code.Code1" });
//db.LTrees.Add(new LTreeModel { Code = "Code2", LTree = "Code.Code2" });
//db.LTrees.Add(new LTreeModel { Code = "Code3", LTree = "Code.Code1.Code3" });

//db.SaveChanges();

//var models1 = db.LTrees.Where(n => n.LTree.IsAncestorOf("Code")).ToList();
//var models2 = db.LTrees.Where(n => n.LTree.IsDescendantOf("Code")).ToList();

//var models3 = db.LTrees.Where(n => n.LTree.IsDescendantOf("Code.Code1.Code3")).ToList();
//var models4 = db.LTrees.Where(n => n.LTree.IsAncestorOf("Code.Code1.Code3")).ToList();

Console.WriteLine("Hello, World!");

