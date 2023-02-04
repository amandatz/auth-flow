using AuthFlow.Domain.Core.Users;

namespace AuthFlow.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string AccessToken,
    string RefreshToken
);