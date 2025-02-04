using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.DTO;

public class UserDto : BaseDto
{

    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
