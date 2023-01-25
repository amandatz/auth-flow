using AuthFlow.Application.Authentication.Common;

namespace AuthFlow.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResult> RefreshAsync(string refreshToken);
    Task LogoutAsync(string refreshToken);
}