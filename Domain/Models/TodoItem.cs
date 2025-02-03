using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Domain.Models;

public class TodoItem : BaseModel
{


    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public long UserId { get; set; }
    public long TodoItemTagId { get; set; }

}
