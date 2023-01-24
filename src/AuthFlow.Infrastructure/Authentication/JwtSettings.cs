namespace AuthFlow.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string AccessTokenSecret { get; init; } = null!;
    public int AccessExpiryMinutes { get; init; }
    public string RefreshTokenSecret { get; init; } = null!;
    public int RefreshExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}