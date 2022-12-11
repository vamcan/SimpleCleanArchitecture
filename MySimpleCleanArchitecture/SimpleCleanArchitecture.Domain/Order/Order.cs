using SimpleCleanArchitecture.Domain.Base;
using SimpleCleanArchitecture.Domain.ValueObjects;

namespace SimpleCleanArchitecture.Domain.Order
{
    public class Order :  IAggregateRoot
    {
        public Order()
        {
            _orderDetails = new List<OrderDetail>();
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Email Email { get; private set; }
      
        public decimal TotalPrice { get; private set; }
        private List<OrderDetail> _orderDetails;

        public IReadOnlyCollection<OrderDetail> OrderDetails
        {
            get
            {
                return _orderDetails.AsReadOnly();
            }
        }

        public void AddOrderDetail(OrderDetail detail)
        {
            _orderDetails.Add(detail);
        }

        public void RemoveOrderDetail(OrderDetail detail)
        {
            _orderDetails.Remove(detail);
        }

        public void CalculatePrice()
        {
            TotalPrice = _orderDetails.Sum(c => c.Price);
        }

    }
}
