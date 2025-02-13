using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddScoped<ITodoItemTagRepository, TodoItemTagRepository>();

// API SERVICES

builder.Services.AddScoped<ITodoItemService<TodoItem, TodoItemDto>, TodoItemService>();
builder.Services.AddScoped<ITodoItemTagService<TodoItemTag, TodoItemTagDto>, TodoItemTagService>();

//VALIDATORS

builder.Services.AddScoped<IValidator<TodoItemDto>, TodoItemValidator>();
builder.Services.AddScoped<IValidator<TodoItemTagDto>, TodoItemTagValidator>();

// ENDPOINTS

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorization();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddApiEndpoints();


var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(frontendUrl)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});




var app = builder.Build();

app.UseCors("AllowSpecificOrigins");

app.MapGet("/manage/info-custom", async (UserManager<User> userManager, HttpContext httpContext) =>
{
    var user = await userManager.GetUserAsync(httpContext.User);
    if (user is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(new
    {
        id = user.Id,
        email = user.Email,
    });
}).RequireAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<User>();

await app.RunAsync();
