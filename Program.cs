using Microsoft.EntityFrameworkCore;
using FluentValidation;
using TodoApi.Application.Interfaces;
using TodoApi.Application.Services;
using TodoApi.Application.Validations;
using TodoApi.Application.DTO;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructur.Context;
using TodoApi.Infrastructure.Repositories;





var builder = WebApplication.CreateBuilder(args);

// CONTROLLERS

builder.Services.AddControllers();

// CONTEXTS

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("TodoList"));

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
