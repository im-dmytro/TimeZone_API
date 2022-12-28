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

app.MapGet("/timezone", async (CountryTimeApiContext dataContext) => await dataContext.CountryCapitals.ToListAsync());


app.Run();

