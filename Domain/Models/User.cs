using System;
using Microsoft.AspNetCore.Identity;


namespace TodoApi.Domain.Models;

public class User : IdentityUser
{
    public ICollection<TodoItem>? TodoItems { get; set; }
}
