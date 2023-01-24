using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthFlow.Application.Common.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace AuthFlow.Infrastructure.Authentication.TokenGenerators;

public class TokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public TokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string Generate(string secretKey, string issuer, string audience, double expirationMinutes, IEnumerable<Claim>? claims = null)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}