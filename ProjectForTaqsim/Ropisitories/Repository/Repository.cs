using Microsoft.EntityFrameworkCore;
using ProjectForTaqsim.Context;
using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Ropisitories.IRepository;
using System.Linq.Expressions;

namespace ProjectForTaqsim.Ropisitories.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public IQueryable<TEntity> AllAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        if(expression == null)
        {
            return _dbSet;
        }
        return _dbSet.Where(expression);
    }

    public async ValueTask<TEntity> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async ValueTask DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async ValueTask<TEntity?> GetASync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }
}
