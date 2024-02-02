using EntityFramework.Sqlite;
using EntityFramework.Sqlite.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OData.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleDatasController(SqliteDbContext sqliteDbContext) : ControllerBase {
    [EnableQuery(PageSize = 3)]
    [HttpGet]
    public IQueryable<ExampleData> Get() {
        return sqliteDbContext.ExampleDatas;
    }
}
