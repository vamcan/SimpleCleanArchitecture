using MediatR;

namespace SimpleCleanArchitecture.Application.Order.Query
{
    public class GetOrderListQuery: IRequest<List<Domain.Order.Order>>
    {
    }
}
