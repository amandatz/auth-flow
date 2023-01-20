using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.User.ValueObjects;

public sealed class Email : ValueObject
{
    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string email) => new(email);

    public override string ToString() => Value;

    public static Email CreateNew(string value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}