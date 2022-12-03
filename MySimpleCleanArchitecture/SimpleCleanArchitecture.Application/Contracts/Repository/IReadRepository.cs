using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCleanArchitecture.Application.Base;
using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Application.Contracts.Repository
{
    internal interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
