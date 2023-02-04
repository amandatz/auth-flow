using AuthFlow.Domain.Core.RefreshToken;
using AuthFlow.Domain.Core.RefreshToken.ValueObjects;
using AuthFlow.Domain.Core.Users.ValueObjects;

namespace AuthFlow.Application.Common.Interfaces.Persistence;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByToken(string token);
    Task Insert(RefreshToken refreshToken);
    Task Delete(RefreshTokenId id);
    Task DeleteByUserId(UserId userId);
}