using SimpleCleanArchitecture.Application.Contracts.Repository;
using SimpleCleanArchitecture.Domain.Base;
using SimpleCleanArchitecture.Infrastructure.EntityFramework.Core;

namespace SimpleCleanArchitecture.Infrastructure.EntityFramework
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
