using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Bases;

public class TodoContext : DbContext
{

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems {get; set;} = null!;
    public DbSet<User> User {get; set;} = null!;
    public DbSet<TodoItemTag> TodoItemTag { get; set; } = null!;

}
