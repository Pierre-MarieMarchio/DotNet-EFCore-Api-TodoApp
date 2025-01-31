using System;
using TodoApi.Bases;

namespace TodoApi.Models;

public class TodoItemTag : BaseModel
{
    public string? Name { get; set; }

    
    public List<TodoItem>? TodoItems { get; set; }

}
