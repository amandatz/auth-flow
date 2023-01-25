using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Domain.Core.User.Entities;
using AuthFlow.Domain.Core.User.ValueObjects;

namespace AuthFlow.Infrastructure.Persistence;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private static readonly List<UserRefreshToken> _refreshTokens = new();

    public Task<UserRefreshToken?> GetByToken(string token)
    {
        return Task.FromResult(_refreshTokens.SingleOrDefault(rt => rt.Token == token));
    }

    public Task Insert(UserRefreshToken refreshToken)
    {
        _refreshTokens.Add(refreshToken);
        return Task.CompletedTask;
    }

    public Task Delete(UserRefreshTokenId id)
    {
        _refreshTokens.RemoveAll(rt => rt.Id == id);
        return Task.CompletedTask;
    }

    public Task DeleteByUserId(UserId userId)
    {
        _refreshTokens.RemoveAll(rt => rt.UserId == userId);
        return Task.CompletedTask;
    }
}