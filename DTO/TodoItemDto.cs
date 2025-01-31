using System;
using TodoApi.Bases;

namespace TodoApi.DTO;

public class TodoItemDto : BaseDto
{

    public string? Title { get; set; }
    public bool IsComplete { get; set; }
}
