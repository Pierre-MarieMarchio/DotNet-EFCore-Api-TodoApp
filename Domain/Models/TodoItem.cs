using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Domain.Models;

public class TodoItem : BaseModel
{
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ICollection<TodoItemTag>? TodoItemTags { get; set; }
}
