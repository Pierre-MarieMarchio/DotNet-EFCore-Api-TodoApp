using System;
using TodoApi.Domain.Commons;

namespace TodoApi.Application.Commons;

public interface IBaseApiService<Tdto>
    where Tdto : BaseDto
{
    Task<List<Tdto>> GetAll();
    Task<Tdto> GetOne(long id);
    Task<Tdto> Post(Tdto entityDTO);
    Task<Tdto> Update(long id, Tdto entityDTO);
    Task<bool> Delete(long id);
}
