using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Domain.Order
{
    public class OrderDetail:EntityBase
    {
        public Order Order { get; set;}
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
