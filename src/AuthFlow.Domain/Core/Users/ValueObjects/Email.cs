using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.Core.Users.ValueObjects;

public sealed class Email : ValueObject
{
    #pragma warning disable CS8618
    protected Email() { }
    #pragma warning disable CS8618

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public override string ToString() => Value;

    public static Email Create(string value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}