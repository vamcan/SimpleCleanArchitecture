using Microsoft.EntityFrameworkCore;
using SimpleCleanArchitecture.Domain.Base;
using SimpleCleanArchitecture.Domain.Order;
using SimpleCleanArchitecture.Infrastructure.EntityFramework.Config;

namespace SimpleCleanArchitecture.Infrastructure.EntityFramework
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option
           )
            : base(option)
        {
           
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails=> Set<OrderDetail>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }

     }
}
