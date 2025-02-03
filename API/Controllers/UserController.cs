using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Api.Commons;
using TodoApi.API.Interfaces;
using TodoApi.Application.Commons;
using TodoApi.Domain.DTO;
using TodoApi.Domain.Models;

namespace TodoApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(BaseApiService<User, UserDto> service) : BaseController<User, UserDto>(service), IUserController<UserDto>
    {
       
    }

}
