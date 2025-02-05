using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.DTO;

public class TodoItemTagDto : BaseDto
{
    public required string TagName { get; set; }
}
