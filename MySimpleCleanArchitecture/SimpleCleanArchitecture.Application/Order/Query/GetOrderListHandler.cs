using MediatR;
using SimpleCleanArchitecture.Application.Contracts.Repository;

namespace SimpleCleanArchitecture.Application.Order.Query
{
    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery,List<Domain.Order.Order>>
    {
        private readonly IReadRepository<Domain.Order.Order> _repository;

        public GetOrderListHandler(IReadRepository<Domain.Order.Order> repository)
        {
            _repository = repository;
        }

      
        public Task<List<Domain.Order.Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return _repository.ListAsync(cancellationToken);
        }
    }
}
