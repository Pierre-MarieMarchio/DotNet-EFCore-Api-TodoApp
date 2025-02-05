using System;
using TodoApi.Api.Commons;
using TodoApi.Application.DTO;
using TodoApi.Application.Interfaces;
using TodoApi.Domain.Models;

namespace TodoApi.API.Controllers;

public class TodoItemTagController : BaseController<TodoItemTag, TodoItemTagDto>
{
    public TodoItemTagController(ITodoItemTagService<TodoItemTag, TodoItemTagDto> _service) : base(_service)
    {
    }


}
