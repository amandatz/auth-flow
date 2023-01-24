using AuthFlow.Application.Common.Interfaces.Authentication;
using AuthFlow.Domain.User;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthFlow.Infrastructure.Authentication.TokenGenerators;

public class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly TokenGenerator _tokenGenerator;

    public AccessTokenGenerator(
        IOptions<JwtSettings> jwtSettings,
        TokenGenerator tokenGenerator)
    {
        _jwtSettings = jwtSettings.Value;
        _tokenGenerator = tokenGenerator;
    }

    public string Generate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user!.Id.Value.ToString() ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        return _tokenGenerator.Generate(
            secretKey: _jwtSettings.AccessTokenSecret,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expirationMinutes: _jwtSettings.AccessExpiryMinutes,
            claims: claims);
    }
}