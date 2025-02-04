using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Domain.Models;

public class User : BaseModel
{
    public required string Username { get; set; }
    public required string Email  {get; set;}
    public required string Password {get; set;}
    public ICollection<TodoItem>? TodoItems { get; set; }
}
