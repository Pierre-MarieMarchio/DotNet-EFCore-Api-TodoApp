using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Domain.Models;

public class TodoItemTag : BaseModel
{
    public required string TagName { get; set; }
    public ICollection<TodoItem>? TodoItems { get; set; }
}
