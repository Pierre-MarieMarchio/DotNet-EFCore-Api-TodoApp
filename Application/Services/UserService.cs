using System;
using TodoApi.Application.Commons;
using TodoApi.Application.Interfaces;
using TodoApi.Application.DTO;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Models;
using FluentValidation;



namespace TodoApi.Application.Services;

public class UserService(IUserRepository _userRepository, IValidator<UserDto> _userValidator) : BaseApiService<User, UserDto>(_userRepository, _userValidator), IUserService<UserDto>
{

    protected override UserDto MapToDTO(User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            Password = entity.Password,

        };
    }

    protected override User MapToEntity(UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password,

        };
    }

    protected override void CopyDtoToEntity(UserDto dto, User entity)
    {
        entity.Id = dto.Id;
        entity.Username = dto.Username;
        entity.Email = dto.Email;
        entity.Password = dto.Password;

    }
}
