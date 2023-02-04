using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.Core.RefreshToken.ValueObjects;

public sealed class RefreshTokenId : ValueObject
{
    private RefreshTokenId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static RefreshTokenId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static RefreshTokenId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}