using CQRSWithMinimalAPI.API.Endpoints;
using CQRSWithMinimalAPI.API.Middlewares;
using CQRSWithMinimalAPI.Application.Customers.Commands;
using CQRSWithMinimalAPI.Application.Interfaces;
using CQRSWithMinimalAPI.Infrastructure.Persistence;
using CQRSWithMinimalAPI.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(typeof(CreateCustomerCommandHandler).Assembly);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CQRS with Minimal API",
        Version = "v1",
        Description = "API documentation for CQRS-based application with Minimal API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Rohit Salune",
            Email = "salunkerohit119@gmail.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Enable Swagger UI
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS with Domain Events API v1");
        options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
//}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapCustomerEndpoints();

app.Run();

