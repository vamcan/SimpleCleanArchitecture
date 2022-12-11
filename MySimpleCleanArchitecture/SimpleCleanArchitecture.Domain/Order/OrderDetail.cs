namespace SimpleCleanArchitecture.Domain.Order
{
    public class OrderDetail
    {
        private OrderDetail()
        {
        }

        public static OrderDetail CreateOrderDetail(Order order, string name, int count,decimal price)
        {
            return new OrderDetail()
            {
                Id = Guid.NewGuid(),
                Order = order,
                Name = name,
                Count = count,
                Price = price
            };
        }
        public Guid Id { get;private set; }
        public Order Order { get; private set; }
        public string Name { get; private set; }
        public int Count { get; private set; }
        public decimal Price{ get; private set; }

        public void SetPrice(decimal price)
        {
            Price=price;
            Order.CalculatePrice();
        }
    }
}
