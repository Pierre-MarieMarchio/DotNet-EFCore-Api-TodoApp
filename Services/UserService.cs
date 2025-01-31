using System;
using TodoApi.Bases;
using TodoApi.DTO;
using TodoApi.Interfaces;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class UserService(IUserRepository userRepository) : BaseService<User, UserDto>(userRepository), IUserService
{

    protected override UserDto MapToDTO(User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Name = entity.Name,
            TodoItems = entity.TodoItems
        };
    }

    protected override User MapToEntity(UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Name = dto.Name,
            TodoItems = dto.TodoItems
        };
    }

    protected override void CopyDtoToEntity(UserDto dto, User entity)
    {
        entity.Id = dto.Id;
        entity.Name = dto.Name;
        entity.TodoItems = dto.TodoItems;
    }
}
