using System;
using TodoApi.Domain.Commons;
using TodoApi.Domain.Models;

namespace TodoApi.Domain.Interfaces;

public interface ITodoItemRepository : IBaseRepository<TodoItem>
{

}
