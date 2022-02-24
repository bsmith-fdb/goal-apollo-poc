using FDB.Apollo.IPT.Service.Models;
using FDB.Apollo.IPT.Service.Models.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetConnectionString("postgres");

if (string.IsNullOrEmpty(connString))
{
    connString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_postgres") ?? string.Empty;
}

builder.Services.AddDbContext<postgresContext>(opt => opt.UseNpgsql(connString));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
