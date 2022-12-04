using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Moq;
using SimpleCleanArchitecture.Application.Contracts.Repository;
using SimpleCleanArchitecture.Application.Order.Command;
using SimpleCleanArchitecture.Application.Services.Email;

namespace SimpleCleanArchitecture.UnitTests.Order.Handler
{

    public class AddOrderHandlerTests
    {
        private readonly AddOrderHandler _handler;
        private readonly Mock<IRepository<Domain.Order.Order>> _repository;
        private readonly Mock<IMediator> _mediator;
        public AddOrderHandlerTests()
        {
            _mediator= new Mock<IMediator>();
            _repository = new Mock<IRepository<Domain.Order.Order>>();
            _handler = new AddOrderHandler(_repository.Object, _mediator.Object);
        }

        [Fact]
        public async Task ThrowExceptionWithNullCommand()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task SaveChangesShouldCallWithNotNullCommand()
        {
            var command= new AddOrderCommand(){Order = new Domain.Order.Order()};
            await _handler.Handle(command, CancellationToken.None);
            _repository.Verify(c=>c.SaveChangesAsync(CancellationToken.None),Times.Once);
        }

        [Fact]
        public async Task PublishShouldCallWithNotNullCommand()
        {
            var command = new AddOrderCommand() { Order = new Domain.Order.Order() };
            await _handler.Handle(command, CancellationToken.None);
            _mediator.Verify(c => c.Publish(It.IsAny<EmailSenderCommand>(),CancellationToken.None), Times.Once);
        }

    }
}
