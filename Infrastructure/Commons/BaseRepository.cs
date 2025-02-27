using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Commons;
using TodoApi.Infrastructure.Persistence.Context;

namespace TodoApi.Infrastructure.Commons;

public abstract class BaseRepository<TModel>(DatabaseContext context) : IBaseRepository<TModel>
    where TModel : BaseModel
{

    protected readonly DatabaseContext _context = context;
    protected readonly DbSet<TModel> _dbSet = context.Set<TModel>();

    public async Task<List<TModel>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TModel?> GetOne(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TModel> Add(TModel entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    public async Task<TModel> Update(TModel entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
