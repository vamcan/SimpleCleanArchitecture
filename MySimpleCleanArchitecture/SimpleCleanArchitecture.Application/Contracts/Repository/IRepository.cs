using SimpleCleanArchitecture.Application.Base;
using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Application.Contracts.Repository
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
