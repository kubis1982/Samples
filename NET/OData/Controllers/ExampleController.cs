using EntityFramework.Sqlite;
using EntityFramework.Sqlite.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OData.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController(SqliteDbContext sqliteDbContext) : ControllerBase { 
    [HttpGet(Name = "GetExampleDatas")]
    public IEnumerable<ExampleData> Get()
    {
        return sqliteDbContext.ExampleDatas.ToArray();
    }
}
