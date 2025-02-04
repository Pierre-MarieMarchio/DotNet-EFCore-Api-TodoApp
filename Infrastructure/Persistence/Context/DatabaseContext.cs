using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Models;
using TodoApi.Infrastructure.Commons;
using TodoApi.Infrastructure.Persistence.Configurations;


namespace TodoApi.Infrastructure.Persistence.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<TodoItemTag> TodoItemTag { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BaseConfiguration<User>());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new BaseConfiguration<TodoItem>());
        modelBuilder.ApplyConfiguration(new TodoItemConfiguration());

        modelBuilder.ApplyConfiguration(new BaseConfiguration<TodoItemTag>());
        modelBuilder.ApplyConfiguration(new TodoItemTagConfiguration());

    }

}
