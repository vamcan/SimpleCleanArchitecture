using Microsoft.EntityFrameworkCore;
using SimpleCleanArchitecture.Domain.Base;
using SimpleCleanArchitecture.Domain.Order;
using SimpleCleanArchitecture.Infrastructure.Base;

namespace SimpleCleanArchitecture.Infrastructure.EntityFramework
{
    public class AppDbContext:DbContext
    {
        private readonly IDomainEventDispatcher? _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options,
            IDomainEventDispatcher? dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails=> Set<OrderDetail>();
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
