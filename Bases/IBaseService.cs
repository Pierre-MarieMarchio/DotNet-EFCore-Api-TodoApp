using System;

namespace TodoApi.Bases;

public interface IBaseService<TDTO>
{
    Task<List<TDTO>> GetAll();
    Task<TDTO> GetOne(long id);
    Task<TDTO> Post(TDTO entityDTO);
    Task<TDTO> Update(long id, TDTO entityDTO);
    Task<bool> Delete(long id);
}
