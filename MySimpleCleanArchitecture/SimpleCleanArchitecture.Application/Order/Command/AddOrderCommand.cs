using MediatR;

namespace SimpleCleanArchitecture.Application.Order.Command
{
    public class AddOrderCommand:IRequest<Domain.Order.Order>
    {
        public Domain.Order.Order Order { get; set; }
    }
}
