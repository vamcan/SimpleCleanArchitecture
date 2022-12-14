using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCleanArchitecture.Application.Order.Command;
using SimpleCleanArchitecture.Application.Order.Query;
using SimpleCleanArchitecture.Domain.Order;
using SimpleCleanArchitecture.Domain.ValueObjects;
using SimpleCleanArchitecture.WebApp.ApiModels;

namespace SimpleCleanArchitecture.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private readonly IMediator _mediatR;

        public OrderController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var addOrderCommand = new AddOrderCommand()
            {
                Order = new Order()
                {
                    Email = new Email(request.Email),
                    Description = request.Description,
                    Title = request.Title,
                }
            };
           var order = await _mediatR.Send(addOrderCommand, cancellationToken);
            return Ok(order);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
        {
            var getOrdersQuery = new GetOrderListQuery();
            var orders = await _mediatR.Send(getOrdersQuery, cancellationToken);
            return Ok(orders);
        }
    }
}
