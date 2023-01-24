using AuthFlow.Domain.Common.Models;
using AuthFlow.Domain.User.ValueObjects;

namespace AuthFlow.Domain.User.Entities;

public sealed class UserRefreshToken : Entity<UserRefreshTokenId>
{
    private UserRefreshToken(UserRefreshTokenId id, UserId userId, string token) : base(id)
    {
        UserId = userId;
        Token = token;
    }

    public UserId UserId { get; }
    public string Token { get; }

    public static UserRefreshToken Create(UserId userId, string token)
    {
        return new(UserRefreshTokenId.CreateUnique(), userId, token);
    }
}