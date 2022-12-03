using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Domain.ValueObjects
{
    public class Email : ValueObjectBase
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
