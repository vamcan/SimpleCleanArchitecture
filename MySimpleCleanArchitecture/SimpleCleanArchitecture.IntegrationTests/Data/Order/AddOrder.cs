using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCleanArchitecture.Domain.ValueObjects;

namespace SimpleCleanArchitecture.IntegrationTests.Data.Order
{
    public class AddOrder : BaseEfRepoTestFixture<Domain.Order.Order>
    {
        [Fact]
        public async Task AddOrderShouldAddOrderInDb()
        {
            var description = "TestDescription";
            var order = new Domain.Order.Order()
            {
                Description = description,
                Email = new Email("reza@gmail.com"),
                Title = "Title"
            };
            var repository = GetRepository();
            await repository.AddAsync(order, CancellationToken.None);

            var newOrder = (await repository.ListAsync()).FirstOrDefault();
            Assert.Equal(newOrder.Description, description);

        }
    }
}
