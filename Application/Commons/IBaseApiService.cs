using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.Commons;

public interface IBaseApiService<TModel, TDto>
    where TDto : BaseDto
{
    Task<List<TDto>> GetAll();
    Task<TDto> GetOne(Guid id);
    Task<TDto> Post(TDto entityDTO);
    Task<TDto> Update(Guid id, TDto entityDTO);
    Task<bool> Delete(Guid id);

    abstract TDto MapToDTO(TModel entity);
    abstract TModel MapToEntity(TDto dto);
    abstract void CopyDtoToEntity(TDto dto, TModel entity);
}
