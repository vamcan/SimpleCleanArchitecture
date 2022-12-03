using SimpleCleanArchitecture.Application.Base;
using Microsoft.EntityFrameworkCore;

namespace SimpleCleanArchitecture.Infrastructure.EntityFramework.Core
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)

        {
            this._dbContext = dbContext;
        }

        /// <inheritdoc/>
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Add(entity);

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().AddRange(entities);

            await SaveChangesAsync(cancellationToken);

            return entities;
        }

        /// <inheritdoc/>
        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);

            await SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().UpdateRange(entities);

            await SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().RemoveRange(entities);

            await SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().CountAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().AnyAsync(cancellationToken);
        }

    }

}
