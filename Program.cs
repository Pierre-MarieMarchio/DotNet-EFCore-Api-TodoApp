using Microsoft.EntityFrameworkCore;
using TodoApi.Application.Commons;
using TodoApi.Application.Services;
using TodoApi.Domain.DTO;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Models;
using TodoApi.Infrastructur.Context;
using TodoApi.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>(opt =>
    // opt.UseMySQL(builder.Configuration.GetConnectionString("TodoApi")));
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<BaseApiService<User, UserDto>, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
