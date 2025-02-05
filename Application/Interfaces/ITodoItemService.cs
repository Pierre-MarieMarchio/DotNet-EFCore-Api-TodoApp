using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.Interfaces;

public interface ITodoItemService<TModel, TDto> : IBaseApiService<TModel, TDto>
    where TDto : BaseDto
{

}
