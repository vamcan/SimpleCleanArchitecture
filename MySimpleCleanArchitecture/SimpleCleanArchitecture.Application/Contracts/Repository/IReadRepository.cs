using SimpleCleanArchitecture.Application.Base;
using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Application.Contracts.Repository
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
