using System;
using FluentValidation;
using TodoApi.Application.Commons;
using TodoApi.Application.DTO;
using TodoApi.Application.Interfaces;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Models;

namespace TodoApi.Application.Services;

public class TodoItemService : BaseApiService<TodoItem, TodoItemDto>, ITodoItemService<TodoItem, TodoItemDto>
{
  
    public TodoItemService(ITodoItemRepository repository, IValidator<TodoItemDto> validator)
        : base(repository, validator)
    {
    }

    public override TodoItemDto MapToDTO(TodoItem entity)
    {
        return new TodoItemDto
        {
            Id = entity.Id,
            Title = entity.Title,
            IsComplete = entity.IsComplete,
            UserId = entity.UserId

        };
    }

    public override TodoItem MapToEntity(TodoItemDto dto)
    {
        return new TodoItem
        {
            Id = dto.Id,
            Title = dto.Title,
            IsComplete = dto.IsComplete,
            UserId = dto.UserId
        };
    }

    public override void CopyDtoToEntity(TodoItemDto dto, TodoItem entity)
    {
        entity.Id = dto.Id;
        entity.Title = dto.Title;
        entity.IsComplete = dto.IsComplete;
        entity.UserId = dto.UserId;
    }
}

