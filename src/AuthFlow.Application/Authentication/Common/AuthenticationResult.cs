using AuthFlow.Domain.User;

namespace AuthFlow.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string AccessToken,
    string RefreshToken
);