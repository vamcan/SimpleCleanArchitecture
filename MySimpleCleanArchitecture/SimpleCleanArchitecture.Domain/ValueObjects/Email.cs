using SimpleCleanArchitecture.Domain.Base;

namespace SimpleCleanArchitecture.Domain.ValueObjects
{
    public class Email : BaseValueObject<Email>
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; }


        public override bool ObjectIsEqual(Email email)
        {
            return email.Value == Value;
        }

        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
