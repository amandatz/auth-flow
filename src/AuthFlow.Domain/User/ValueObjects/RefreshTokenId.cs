using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.User.ValueObjects;

public sealed class UserRefreshTokenId : ValueObject
{
    private UserRefreshTokenId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserRefreshTokenId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}