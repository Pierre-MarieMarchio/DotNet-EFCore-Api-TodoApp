using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Domain.DTO;

public class UserDto : BaseDto
{

    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
