using System;
using TodoApi.Bases;

namespace TodoApi.Models;

public class TodoItem : BaseModel
{


    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public long TodoItemTagId { get; set; }
    public TodoItemTag? TodoItemTag { get; set; }

}
