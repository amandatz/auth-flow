using AuthFlow.Domain.User;

namespace AuthFlow.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string AccessToken,
    string RefreshToken
);