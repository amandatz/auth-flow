using AuthFlow.Domain.Core.User;

namespace AuthFlow.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string AccessToken,
    string RefreshToken
);