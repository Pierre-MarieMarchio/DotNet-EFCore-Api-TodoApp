using System;

namespace TodoApi.Domain.Commons;

public interface IBaseRepository<Tmodel>
    where Tmodel : BaseModel
{
    Task<List<Tmodel>> GetAll();
    Task<Tmodel?> GetOne(long id);
    Task<Tmodel> Add(Tmodel entity);
    Task<Tmodel> Update(Tmodel entity);
    Task<bool> Delete(long id);
}
