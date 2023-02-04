using AuthFlow.Domain.Common.Models;
using AuthFlow.Domain.Core.RefreshToken.ValueObjects;
using AuthFlow.Domain.Core.Users.ValueObjects;

namespace AuthFlow.Domain.Core.RefreshToken;

public sealed class RefreshToken : AggregateRoot<RefreshTokenId>
{
    private RefreshToken(RefreshTokenId id, UserId userId, string token) : base(id)
    {
        UserId = userId;
        Token = token;
    }

    public UserId UserId { get; }
    public string Token { get; }

    public static RefreshToken Create(UserId userId, string token)
    {
        return new(RefreshTokenId.CreateUnique(), userId, token);
    }
}