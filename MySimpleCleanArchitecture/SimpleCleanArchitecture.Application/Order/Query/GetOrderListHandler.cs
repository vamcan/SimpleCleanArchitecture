using MediatR;
using SimpleCleanArchitecture.Application.Contracts.Repository;

namespace SimpleCleanArchitecture.Application.Order.Query
{
    public class GetOrderListHandler : INotificationHandler<GetOrderListQuery>
    {
        private readonly IReadRepository<Domain.Order.Order> _repository;

        public GetOrderListHandler(IReadRepository<Domain.Order.Order> repository)
        {
            _repository = repository;
        }

        public Task Handle(GetOrderListQuery notification, CancellationToken cancellationToken)
        {
            return _repository.ListAsync(cancellationToken);
        }
    }
}
