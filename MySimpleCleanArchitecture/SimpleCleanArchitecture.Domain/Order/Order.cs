using SimpleCleanArchitecture.Domain.Base;
using SimpleCleanArchitecture.Domain.ValueObjects;

namespace SimpleCleanArchitecture.Domain.Order
{
    public class Order:EntityBase,IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Email Email { get; set; }
    }
}
