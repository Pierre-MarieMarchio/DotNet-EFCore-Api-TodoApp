using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Models;
using TodoApi.Infrastructure.Commons;
using TodoApi.Infrastructure.Persistence.Configurations;


namespace TodoApi.Infrastructure.Persistence.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<TodoItemTag> TodoItemTag { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BaseConfiguration<TodoItem>());
            builder.ApplyConfiguration(new TodoItemConfiguration());

            builder.ApplyConfiguration(new BaseConfiguration<TodoItemTag>());
            builder.ApplyConfiguration(new TodoItemTagConfiguration());
    }

}
