namespace SimpleCleanArchitecture.Application.Base
{
    public interface IReadRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
        Task<List<T>?> GetAllAsync<TId>(CancellationToken cancellationToken = default) where TId : notnull;
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    }
}
