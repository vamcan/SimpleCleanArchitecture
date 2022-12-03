﻿using MediatR;
using SimpleCleanArchitecture.Application.Contracts.Repository;
using SimpleCleanArchitecture.Application.Services.Email;

namespace SimpleCleanArchitecture.Application.Order.Command
{
    public class AddOrderHandler : INotificationHandler<AddOrderCommand>
    {
        private readonly IRepository<Domain.Order.Order> _repository;
        private readonly IMediator _mediator;

        public AddOrderHandler(IRepository<Domain.Order.Order> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task Handle(AddOrderCommand notification, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(notification.Order, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new EmailSenderCommand() { Body = "body", From = "from", Subject = "subject", To = "to" }, cancellationToken);
        }
    }
}
