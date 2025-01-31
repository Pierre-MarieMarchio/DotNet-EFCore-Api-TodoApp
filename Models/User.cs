using System;
using TodoApi.Bases;

namespace TodoApi.Models;

public class User : BaseModel
{

    public string? Name { get; set; }
    public List<TodoItem>? TodoItems {get; set;}
    public string? Email  {get; set;}
}
