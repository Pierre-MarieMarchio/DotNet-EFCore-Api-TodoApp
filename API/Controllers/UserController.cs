using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Api.Commons;
using TodoApi.Application.DTO;
using TodoApi.Domain.Models;
using TodoApi.Application.Interfaces;

namespace TodoApi.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController<User, UserDto>
{
    public UserController(IUserService<User, UserDto> _service) : base(_service)
    {
    }

}
