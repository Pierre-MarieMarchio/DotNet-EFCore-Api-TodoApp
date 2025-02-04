using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DotNetEnv;
using TodoApi.Application.Interfaces;
using TodoApi.Application.Services;
using TodoApi.Application.Validations;
using TodoApi.Application.DTO;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence.Context;
using TodoApi.Infrastructure.Repositories;





var builder = WebApplication.CreateBuilder(args);

Env.Load();

// CONTROLLERS

builder.Services.AddControllers();

// CONTEXTS

var connectionString = $"Server={Environment.GetEnvironmentVariable("DATABASE_SERVER")};Database={Environment.GetEnvironmentVariable("DATABASE_NAME")};User Id={Environment.GetEnvironmentVariable("DATABASE_USER")};Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")};TrustServerCertificate=True;";
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));

// REPOSITORIES

builder.Services.AddScoped<IUserRepository, UserRepository>();

// SERVICES

builder.Services.AddScoped<IUserService<UserDto>, UserService>();

//VALIDATORS

builder.Services.AddScoped<IValidator<UserDto>, UserValidator>();

// ENDPOINTS

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
