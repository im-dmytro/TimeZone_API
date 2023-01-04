using Microsoft.EntityFrameworkCore;
using TimeZoneAPI;
using TimeZoneAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CountryTimeApiContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/timeZones", async (CountryTimeApiContext dataContext) =>
{
    return await QueryableMethods.GetCountriesTimeInfo(dataContext);
});

app.MapGet("/timezone/{codeCountry}", async (CountryTimeApiContext dataContext, string codeCountry) =>
{
    return await QueryableMethods.GetCountryTimeInfo(dataContext, codeCountry);
});
app.MapGet("/currentCountryTime/{codeCountry}", async (CountryTimeApiContext datacontext, string codeCountry) =>
{
    return await QueryableMethods.GetCurrentCountryTimeZoneInfo(datacontext, codeCountry);
});

app.Run();

