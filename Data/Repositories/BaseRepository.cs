using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    protected readonly DataContext _context = context;
    protected DbSet<TEntity> _db = context.Set<TEntity>();

    private IDbContextTransaction _transaction = null!;

    #region Transaction Management

    public virtual async Task BeginTransactionAsync()
    {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }
    public virtual async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }
    public virtual async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    #endregion

    public virtual async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _db.AddAsync(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        var entities = await _db.ToListAsync();
        return entities;
    } 

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _db.FirstOrDefaultAsync(expression);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _db.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _db.Remove(entity);
    }
}
