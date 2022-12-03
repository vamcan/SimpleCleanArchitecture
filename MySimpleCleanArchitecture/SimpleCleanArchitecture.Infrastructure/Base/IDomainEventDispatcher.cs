using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Infrastructure.Base
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
    }
}
