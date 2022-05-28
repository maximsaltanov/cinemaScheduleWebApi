using CinemaScheduleWebApp.Database;
using CinemaScheduleWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// setup InMemory database as singleton - for testing purposes only!!!
builder.Services.AddDbContext<CinemaScheduleDbContext>(opt => opt.UseInMemoryDatabase("CinemaScheduleDatabase"), ServiceLifetime.Singleton);
builder.Services.AddScoped<ICinemaScheduleService, CinemaScheduleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();