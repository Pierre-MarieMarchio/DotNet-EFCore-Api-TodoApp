using System;

namespace TodoApi.Domain.Commons;

public interface IBaseRepository<TModel>
    where TModel : BaseModel
{
    Task<List<TModel>> GetAll();
    Task<TModel?> GetOne(Guid id);
    Task<TModel> Add(TModel entity);
    Task<TModel> Update(TModel entity);
    Task<bool> Delete(Guid id);
}
