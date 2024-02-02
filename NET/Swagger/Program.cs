using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(n => {
    //n.SchemaFilter<AddFluentValidationRules>();
    n.SwaggerDoc("v1",
        new OpenApiInfo {
            Title = "AddingStuffAndChecking",
            Version = "v1",
            Description = "An API to get students",
            TermsOfService = new Uri("https://firma.com/terms"),
            Contact = new OpenApiContact {
                Name = "Mariusz Œwi¹tnicki",
                Email = "dowolny@gmail.com",
                Url = new Uri("https://twitter.com"),
            },
            License = new OpenApiLicense {
                Name = "AddingStuffAndChecking API",
                Url = new Uri("https://firma.com/license"),
            },
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    n.IncludeXmlComments(xmlPath);
});
builder.Services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);
// Add FV
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddFluentValidationRulesToSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () => {
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPost("/contractors", (Contractor contractor) => {
})
.WithName("CreateContractor")
.WithOpenApi().AddEndpointFilter<ValidationFilter<Contractor>>();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal class Contractor {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

class ContractorValidator : AbstractValidator<Contractor> {
    public ContractorValidator() {
        RuleFor(n => n.Name).NotEmpty();
        RuleFor(n => n.Description).MaximumLength(20);
    }
}

public class ValidationFilter<T> : IEndpointFilter where T : class {
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator) {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next) {
        var obj = context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(T)) as T;

        if (obj is null) {
            return Results.BadRequest();
        }

        var validationResult = await _validator.ValidateAsync(obj);

        if (!validationResult.IsValid) {
            return Results.BadRequest(string.Join("/n", validationResult.Errors));
        }

        return await next(context);
    }
}