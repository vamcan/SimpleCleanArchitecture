using MediatR;

namespace SimpleCleanArchitecture.Application.Order.Command
{
    public class AddOrderCommand:INotification
    {
        public Domain.Order.Order Order { get; set; }
    }
}
