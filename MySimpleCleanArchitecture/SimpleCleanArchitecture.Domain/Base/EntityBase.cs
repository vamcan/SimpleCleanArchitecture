using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCleanArchitecture.Domain.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        private List<DomainEventBase> _domainEvents = new();

        [NotMapped]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
        internal void ClearDomainEvent() => _domainEvents.Clear();
    }
}
