using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleCleanArchitecture.Domain.Base;
using SimpleCleanArchitecture.Infrastructure.EntityFramework;

namespace SimpleCleanArchitecture.IntegrationTests.Data
{
    public class BaseEfRepoTestFixture<T> where T : class, IAggregateRoot
    {
        protected AppDbContext _dbContext;

        public BaseEfRepoTestFixture()
        {
            var options = CreateNewContextOptions();
           

            _dbContext = new AppDbContext(options);
        }
        protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("SimpleCleanArchitecture")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected EfRepository<T> GetRepository()
        {
            return new EfRepository<T>(_dbContext);
        }
    }
}
