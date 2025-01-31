using System;

namespace TodoApi.Bases;

public interface IBaseRepository<TModel>
    where TModel : BaseModel
{
    Task<List<TModel>> GetAll();
    Task<TModel?> GetOne(long id);
    Task<TModel> Add(TModel entity);
    Task<TModel> Update(TModel entity);
    Task<bool> Delete(long id);
}
