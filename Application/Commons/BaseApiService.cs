using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Commons;

namespace TodoApi.Application.Commons;

public abstract class BaseApiService<TModel, TDto> : IBaseApiService<TModel, TDto>
    where TModel : BaseModel
    where TDto : BaseDto
{
    protected readonly IBaseRepository<TModel> _repository;
    protected readonly IValidator<TDto> _validator;

    protected BaseApiService(IBaseRepository<TModel> repository, IValidator<TDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    public virtual async Task<List<TDto>> GetAll()
    {
        var entities = await _repository.GetAll();
        return entities.Select(entity => MapToDTO(entity)).ToList();
    }

    public virtual async Task<TDto> GetOne(Guid id)
    {
        var entity = await _repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(TModel).Name} not found");
        return MapToDTO(entity);
    }

    public virtual async Task<TDto> Post(TDto entityDTO)
    {
        entityDTO.ShouldValidateId = false;
        await this.Validate(entityDTO);

        var entity = MapToEntity(entityDTO);
        var createdEntity = await _repository.Add(entity);
        return MapToDTO(createdEntity);
    }

    public virtual async Task<TDto> Update(Guid id, TDto entityDTO)
    {
        this.ValidateIdMatch(id, entityDTO.Id);

        var entity = await _repository.GetOne(id) ?? throw new KeyNotFoundException($"{typeof(TModel).Name} not found");
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

    public virtual async Task<bool> Delete(Guid id)
    {
        return await _repository.Delete(id);
    }

    protected void ValidateIdMatch(Guid providedId, Guid entityId)
    {
        if (providedId != entityId)
        {
            throw new ArgumentException("The provided ID does not match the ID of the item.");
        }
    }

    protected async Task Validate(TDto entityDTO)
    {
        var validator = await _validator.ValidateAsync(entityDTO);
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }
    }


    public virtual TDto MapToDTO(TModel entity) => throw new NotImplementedException();
    public virtual TModel MapToEntity(TDto dto) => throw new NotImplementedException();
    public virtual void CopyDtoToEntity(TDto dto, TModel entity) => throw new NotImplementedException();
}
