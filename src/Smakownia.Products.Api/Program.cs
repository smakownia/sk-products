using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Smakownia.Products.Api.Middlewares;
using Smakownia.Products.Application;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;
using Smakownia.Products.Infrastructure;
using Smakownia.Products.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(opt => 
{ 
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
})
    .AddJwtBearer(options => 
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["Authorization"];
                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        { 
            ValidateIssuer = false, 
            ValidateAudience = false, 
            ValidateLifetime = true, 
            ValidateIssuerSigningKey = true, 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])) 
        }; 
    });

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
