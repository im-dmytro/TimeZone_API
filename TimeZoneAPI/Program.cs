using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
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

app.MapGet("/timezones", async (CountryTimeApiContext dataContext) =>
{
    return await QueryableMethods.GetCountriesTimeInfo(dataContext);
});

app.MapGet("/timezones/{codeCountry}", async (CountryTimeApiContext dataContext, string codeCountry) =>
{
    return await QueryableMethods.GetCountryTimeInfo(dataContext, codeCountry);
});
app.MapGet("timezones/currentCountryTime/{codeCountry}", async (CountryTimeApiContext datacontext, string codeCountry) =>
{
    return await QueryableMethods.GetCurrentCountryTimeZoneInfo(datacontext, codeCountry);
});
app.MapPut("/timezones/{timezone}", async (string timezone,CountryTimeZone inputTimeZone, CountryTimeApiContext dataContext) =>
{
    return await QueryableMethods.UpdateTimeZoneName(dataContext, timezone, inputTimeZone);
});

app.MapPost("/timezones", async ([FromBody] CountryTimeZone inputTimeZone, CountryTimeApiContext dataContext) =>
{
    return await QueryableMethods.PostTimeZone(dataContext, inputTimeZone);
});

app.MapDelete("/timezones/{timezone}", async (string timezone, [FromBody] CountryTimeZone inputTimeZone, CountryTimeApiContext dataContext) =>
{
    return await QueryableMethods.DeleteTimeZone(dataContext, timezone, inputTimeZone);

});
app.Run();

