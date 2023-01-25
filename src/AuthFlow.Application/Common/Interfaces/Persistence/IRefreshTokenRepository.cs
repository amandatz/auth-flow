using AuthFlow.Domain.Core.User.Entities;
using AuthFlow.Domain.Core.User.ValueObjects;

namespace AuthFlow.Application.Common.Interfaces.Persistence;

public interface IRefreshTokenRepository
{
    Task<UserRefreshToken?> GetByToken(string token);
    Task Insert(UserRefreshToken refreshToken);
    Task Delete(UserRefreshTokenId id);
    Task DeleteByUserId(UserId userId);
}