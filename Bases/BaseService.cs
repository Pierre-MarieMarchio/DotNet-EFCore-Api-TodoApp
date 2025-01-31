using System;

namespace TodoApi.Bases;

public abstract class BaseService<TModel, TDTO>(IBaseRepository<TModel> repository) : IBaseService<TDTO> where TModel : BaseModel
{

    protected readonly IBaseRepository<TModel> _repository = repository;


    public async Task<List<TDTO>> GetAll()
    {
        var entities = await _repository.GetAll();
        return entities.Select(entity => MapToDTO(entity)).ToList();
    }

    public async Task<TDTO> GetOne(long id)
    {
        var entity = await _repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(TModel).Name} not found");
        return MapToDTO(entity);
    }

    public async Task<TDTO> Post(TDTO entityDTO)
    {
        var entity = MapToEntity(entityDTO);
        var createdEntity = await _repository.Add(entity);
        return MapToDTO(createdEntity);
    }

    public async Task<TDTO> Update(long id, TDTO entityDTO)
    {
        var existingEntity = await _repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(TModel).Name} not found");
        CopyDtoToEntity(entityDTO, existingEntity);
        var updatedEntity = await _repository.Update(existingEntity);

        return MapToDTO(updatedEntity);
    }

    public async Task<bool> Delete(long id)
    {
        return await _repository.Delete(id);
    }


    protected virtual TDTO MapToDTO(TModel entity) => throw new NotImplementedException();
    protected virtual TModel MapToEntity(TDTO dto) => throw new NotImplementedException();
    protected virtual void CopyDtoToEntity(TDTO dto, TModel entity) => throw new NotImplementedException();
}
