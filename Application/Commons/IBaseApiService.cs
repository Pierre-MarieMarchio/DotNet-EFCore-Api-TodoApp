using System;
using TodoApi.Application.Commons;

namespace TodoApi.Application.Commons;

public interface IBaseApiService<Tdto>
    where Tdto : BaseDto
{
    Task<List<Tdto>> GetAll();
    Task<Tdto> GetOne(Guid id);
    Task<Tdto> Post(Tdto entityDTO);
    Task<Tdto> Update(Guid id, Tdto entityDTO);
    Task<bool> Delete(Guid id);
}
