using AuthFlow.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;

namespace AuthFlow.Infrastructure.Authentication.TokenGenerators;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly TokenGenerator _tokenGenerator;

    public RefreshTokenGenerator(IOptions<JwtSettings> jwtOptions, TokenGenerator tokenGenerator)
    {
        _jwtSettings = jwtOptions.Value;
        _tokenGenerator = tokenGenerator;
    }

    public string Generate()
    {
        return _tokenGenerator.Generate(
            secretKey: _jwtSettings.RefreshTokenSecret,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expirationMinutes: _jwtSettings.RefreshExpiryMinutes);
    }
}