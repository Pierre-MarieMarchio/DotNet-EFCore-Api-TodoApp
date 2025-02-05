using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Api.Commons;
using TodoApi.Domain.Models;
using TodoApi.Application.DTO;
using TodoApi.Application.Interfaces;


namespace TodoApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoIemController : BaseController<TodoItem, TodoItemDto>
{
    public TodoIemController(ITodoItemService<TodoItem, TodoItemDto> _service) : base(_service)
    {
    }

}
