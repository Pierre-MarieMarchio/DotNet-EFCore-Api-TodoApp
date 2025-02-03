using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Commons;

namespace TodoApi.Application.Commons;

public  class BaseApiService<Tmodel, Tdto>(IBaseRepository<Tmodel> repository) : IBaseApiService<Tdto>
    where Tmodel : BaseModel
    where Tdto : BaseDto
{
    protected IBaseRepository<Tmodel> Repository { get; } = repository;

    public virtual async Task<List<Tdto>> GetAll()
    {
        var entities = await Repository.GetAll();
        return entities.Select(entity => MapToDTO(entity)).ToList();
    }

    public virtual async Task<Tdto> GetOne(long id)
    {
        var entity = await Repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(Tmodel).Name} not found");
        return MapToDTO(entity);
    }

    public virtual async Task<Tdto> Post(Tdto entityDTO)           
    {
        var entity = MapToEntity(entityDTO);
        var createdEntity = await Repository.Add(entity);
        return MapToDTO(createdEntity);
    }

    public virtual async Task<Tdto> Update(long id, Tdto entityDTO)
    {
        if (id != entityDTO.Id)
        {
            throw new ArgumentException("The provided ID does not match the ID of the item.");
        }

        var entity = await Repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(Tmodel).Name} not found");
        CopyDtoToEntity(entityDTO, entity);
        
        try
        {
            await Repository.Update(entity);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbUpdateConcurrencyException("A concurrency conflict occurred while updating the TodoItem.");
        }

        return MapToDTO(entity);
    }

    public virtual async Task<bool> Delete(long id)
    {
        return await Repository.Delete(id);
    }


    protected virtual Tdto MapToDTO(Tmodel entity) => throw new NotImplementedException();
    protected virtual Tmodel MapToEntity(Tdto dto) => throw new NotImplementedException();
    protected virtual void CopyDtoToEntity(Tdto dto, Tmodel entity) => throw new NotImplementedException();
}
