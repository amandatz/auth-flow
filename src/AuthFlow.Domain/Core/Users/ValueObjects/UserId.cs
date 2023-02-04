using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.Core.Users.ValueObjects;

public sealed class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static implicit operator Guid(UserId userId) => userId.Value;

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}