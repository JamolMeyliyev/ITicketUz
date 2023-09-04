using System.Linq.Expressions;

namespace ProjectForTaqsim.Ropisitories.IRepository;

public interface IRepository<TEntity>
{
    public ValueTask<TEntity> CreateAsync(TEntity entity);
    public IQueryable<TEntity> AllAsync(Expression<Func<TEntity, bool>> expression = null);
    public ValueTask<TEntity?> GetASync(Expression<Func<TEntity, bool>> expression);
    public ValueTask DeleteAsync(TEntity entity);
}
