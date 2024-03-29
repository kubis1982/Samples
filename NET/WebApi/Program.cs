using EntityFramework.Sqlite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.Controllers.Model;

static IEdmModel GetEdmModel() {
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<ExampleModel>("ExampleModel");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand()
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(n => {
    var db = new SqliteDbContextFactory().CreateDbContext([]);  
    db.Database.Migrate();  
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

// SSE
app.MapGet("/event-source", async (HttpContext context) => {
    context.Response.ContentType = "text/event-stream";
    context.Response.Headers.CacheControl = "no-cache";
    context.Response.Headers.AccessControlAllowOrigin = "*";

    for (var i = 0; true; ++i) {
        await context.Response.WriteAsync("event: event1\n");
        await context.Response.WriteAsync($"data: Middleware {i} at {DateTime.Now}\r\r");

        await context.Response.Body.FlushAsync();
        await Task.Delay(5 * 1000);
    }
});

app.Run();
