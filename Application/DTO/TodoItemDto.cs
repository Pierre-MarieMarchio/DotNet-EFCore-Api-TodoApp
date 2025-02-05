using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.DTO;

public class TodoItemDto : BaseDto
{
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public Guid UserId { get; set; }
}
