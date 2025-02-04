using System;
using TodoApi.Domain.Interfaces;
using TodoApi.Domain.Models;
using TodoApi.Infrastructure.Commons;
using TodoApi.Infrastructure.Persistence.Context;

namespace TodoApi.Infrastructure.Repositories;

public class TodoItemTagRepository(DatabaseContext context) : BaseRepository<TodoItemTag>(context), ITodoItemTag
{
}
