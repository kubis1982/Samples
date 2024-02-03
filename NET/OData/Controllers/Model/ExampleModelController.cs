using EntityFramework.Sqlite;
using EntityFramework.Sqlite.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore;

namespace OData.Controllers.Model;

[ApiController]
[Route("[controller]")]
public class ExampleModelController(SqliteDbContext sqliteDbContext) : ControllerBase {
    /// <summary>
    /// 
    /// </summary>
    /// <example>
    /// /odata/ExampleModel?$filter=contains(Name, 'Nazwa3')&$expand=items
    /// </example>
    /// <returns></returns>
    [EnableQuery]
    [HttpGet]
    public IQueryable<ExampleModel> Get() {
        return sqliteDbContext.ExampleDatas
            .Select(n => new ExampleModel {
                Id = n.Id,
                Name = n.Name,
                Items = n.Items
                    .Select(n => new ExampleItemModel {
                        Id = n.Id,
                        Name = n.Name
                    })
                    .ToArray()
            });
    }

    //    [HttpGet]
    //    public IQueryable<ExampleModel> Get(ODataQueryOptions opts) {
    //        var settings = new ODataValidationSettings() {
    //            // Initialize settings as needed.
    //            AllowedFunctions = AllowedFunctions.AllMathFunctions
    //        };

    //        opts.Validate(settings);

    //        IQueryable results = opts.ApplyTo(sqliteDbContext.ExampleDatas
    //            .Select(n => new ExampleModel {
    //                Id = n.Id,
    //                Name = n.Name,
    //                Items = n.Items
    //                    .Select(n => new ExampleItemModel {
    //                        Id = n.Id,
    //                        Name = n.Name
    //                    })
    //                    .ToArray()
    //            }));
    //#pragma warning disable CS8603 // Possible null reference return.
    //        return results as IQueryable<ExampleModel>;
    //#pragma warning restore CS8603 // Possible null reference return.
    //    }
}
