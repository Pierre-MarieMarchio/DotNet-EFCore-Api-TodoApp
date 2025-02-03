using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Models;


namespace TodoApi.Infrastructur.Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<TodoItemTag> TodoItemTag { get; set; } = null!;

}
