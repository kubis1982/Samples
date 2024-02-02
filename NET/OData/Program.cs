using EntityFramework.Sqlite;
using EntityFramework.Sqlite.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(n => {
    var db = new SqliteDbContextFactory().CreateDbContext([]);
    if (db.ExampleDatas.Any()) {
        return db;
    }
    db.Database.Migrate();
    db.Add(new ExampleData { Name = "Nazwa1" });
    db.Add(new ExampleData { Name = "Nazwa2" });
    db.Add(new ExampleData { Name = "Nazwa3" });
    db.Add(new ExampleData { Name = "Nazwa4" });
    db.SaveChanges();
    return db;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
