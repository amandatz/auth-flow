using AuthFlow.Application.Authentication.Common;
using AuthFlow.Application.Common.Interfaces.Authentication;
using AuthFlow.Application.Common.Interfaces.Persistence;
using AuthFlow.Domain.Core.RefreshToken;
using AuthFlow.Domain.Core.Users;

namespace AuthFlow.Infrastructure.Authentication;

public class Authenticator : IAuthenticator
{
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public Authenticator(
        IAccessTokenGenerator accessTokenGenerator,
        IRefreshTokenGenerator refreshTokenGenerator,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _refreshTokenGenerator = refreshTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AuthenticationResult> Authenticate(User user)
    {
        var accessToken = _accessTokenGenerator.Generate(user);
        var refreshToken = _refreshTokenGenerator.Generate();
        await _refreshTokenRepository.Insert(RefreshToken.Create(user.Id, refreshToken));

        return new AuthenticationResult(user, accessToken, refreshToken);
    }
}