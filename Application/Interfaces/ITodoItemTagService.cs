using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.Interfaces;

public interface ITodoItemTagService<TModel, TDto> : IBaseApiService<TModel, TDto>
    where TDto : BaseDto
{

}
