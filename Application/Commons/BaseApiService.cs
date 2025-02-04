using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Commons;

namespace TodoApi.Application.Commons;

public abstract class BaseApiService<Tmodel, Tdto>(IBaseRepository<Tmodel> _repository, IValidator<Tdto> _validator) : IBaseApiService<Tdto>
    where Tmodel : BaseModel
    where Tdto : BaseDto
{
    public virtual async Task<List<Tdto>> GetAll()
    {
        var entities = await _repository.GetAll();
        return entities.Select(entity => MapToDTO(entity)).ToList();
    }

    public virtual async Task<Tdto> GetOne(long id)
    {
        var entity = await _repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(Tmodel).Name} not found");
        return MapToDTO(entity);
    }

    public virtual async Task<Tdto> Post(Tdto entityDTO)
    {

        await this.Validate(entityDTO);

        var entity = MapToEntity(entityDTO);
        var createdEntity = await _repository.Add(entity);
        return MapToDTO(createdEntity);
    }

    public virtual async Task<Tdto> Update(long id, Tdto entityDTO)
    {
        this.ValidateIdMatch(id, entityDTO.Id);

        var entity = await _repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(Tmodel).Name} not found");
        CopyDtoToEntity(entityDTO, entity);

        try
        {
            await _repository.Update(entity);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbUpdateConcurrencyException("A concurrency conflict occurred while updating the TodoItem.");
        }

        return MapToDTO(entity);
    }

    public virtual async Task<bool> Delete(long id)
    {
        return await _repository.Delete(id);
    }

    protected void ValidateIdMatch(long providedId, long entityId)
    {
        if (providedId != entityId)
        {
            throw new ArgumentException("The provided ID does not match the ID of the item.");
        }
    }

    protected async Task Validate(Tdto entityDTO)
    {
        var validator = await _validator.ValidateAsync(entityDTO);
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }
    }


    protected virtual Tdto MapToDTO(Tmodel entity) => throw new NotImplementedException();
    protected virtual Tmodel MapToEntity(Tdto dto) => throw new NotImplementedException();
    protected virtual void CopyDtoToEntity(Tdto dto, Tmodel entity) => throw new NotImplementedException();
}
