using AuthFlow.Domain.User;

namespace AuthFlow.Application.Services.Common;

public record AuthenticationResult(
    User User,
    string AccessToken,
    string RefreshToken
);