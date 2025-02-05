using System;
using FluentValidation;
using TodoApi.Application.Commons;
using TodoApi.Application.DTO;
using TodoApi.Application.Interfaces;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Models;

namespace TodoApi.Application.Services;

public class TodoItemTagService : BaseApiService<TodoItemTag, TodoItemTagDto>, ITodoItemTagService<TodoItemTag, TodoItemTagDto>
{
    public TodoItemTagService(ITodoItemTagRepository repository, IValidator<TodoItemTagDto> validator)
        : base(repository, validator)
    {
    }
    
    public override TodoItemTagDto MapToDTO(TodoItemTag entity)
    {
        return new TodoItemTagDto
        {
            Id = entity.Id,
            TagName = entity.TagName


        };
    }

    public override TodoItemTag MapToEntity(TodoItemTagDto dto)
    {
        return new TodoItemTag
        {
            Id = dto.Id,
            TagName = dto.TagName

        };
    }

    public override void CopyDtoToEntity(TodoItemTagDto dto, TodoItemTag entity)
    {
        entity.Id = dto.Id;
        entity.TagName = dto.TagName;

    }
}

