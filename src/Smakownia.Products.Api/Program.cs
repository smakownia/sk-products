using Microsoft.EntityFrameworkCore;
using Smakownia.Products.Api.Middlewares;
using Smakownia.Products.Application;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;
using Smakownia.Products.Infrastructure;
using Smakownia.Products.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductsContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
