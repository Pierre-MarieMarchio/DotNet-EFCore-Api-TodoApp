using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Domain.Models;

public class TodoItemTag : BaseModel
{
    public string? Name { get; set; }

}
