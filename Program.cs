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
using TodoApi.Domain.Models;





var builder = WebApplication.CreateBuilder(args);

Env.Load();

// CONTROLLERS

builder.Services.AddControllers();

// CONTEXTS

var connectionString = $"Server={Environment.GetEnvironmentVariable("DATABASE_SERVER")};Database={Environment.GetEnvironmentVariable("DATABASE_NAME")};User Id={Environment.GetEnvironmentVariable("DATABASE_USER")};Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")};TrustServerCertificate=True;";
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));

// REPOSITORIES

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddScoped<ITodoItemTagRepository, TodoItemTagRepository>();

// API SERVICES

builder.Services.AddScoped<IUserService<User, UserDto>, UserService>();
builder.Services.AddScoped<ITodoItemService<TodoItem, TodoItemDto>, TodoItemService>();
builder.Services.AddScoped<ITodoItemTagService<TodoItemTag, TodoItemTagDto>, TodoItemTagService>();

//VALIDATORS

builder.Services.AddScoped<IValidator<UserDto>, UserValidator>();
builder.Services.AddScoped<IValidator<TodoItemDto>, TodoItemValidator>();
builder.Services.AddScoped<IValidator<TodoItemTagDto>, TodoItemTagValidator>();

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
