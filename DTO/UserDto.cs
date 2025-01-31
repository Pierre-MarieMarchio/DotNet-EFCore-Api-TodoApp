using System;
using TodoApi.Bases;
using TodoApi.Models;

namespace TodoApi.DTO;

public class UserDto : BaseDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public List<TodoItem>? TodoItems { get; set; }
}
