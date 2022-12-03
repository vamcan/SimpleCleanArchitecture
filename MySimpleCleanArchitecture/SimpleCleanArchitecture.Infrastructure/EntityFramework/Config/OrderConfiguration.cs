using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCleanArchitecture.Domain.Order;

namespace SimpleCleanArchitecture.Infrastructure.EntityFramework.Config
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(e => e.Email, n =>
                n.Property(p => p.Value).HasColumnName("Email"));
        }
    }
}
