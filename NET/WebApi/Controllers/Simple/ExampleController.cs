using EntityFramework.Sqlite;
using EntityFramework.Sqlite.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace OData.Controllers.Simple;

[ApiController]
[Route("[controller]")]
public class ExampleController(SqliteDbContext sqliteDbContext) : ControllerBase {
    [EnableQuery(PageSize = 3)]
    [HttpGet]
    public IQueryable<ExampleData> Get() {
        return sqliteDbContext.ExampleDatas;
    }
}
