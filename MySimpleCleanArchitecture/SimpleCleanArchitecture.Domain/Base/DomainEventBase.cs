using MediatR;

namespace SimpleCleanArchitecture.Domain.Base
{
    public abstract class DomainEventBase:INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
