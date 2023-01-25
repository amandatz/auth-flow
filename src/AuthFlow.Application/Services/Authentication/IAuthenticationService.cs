using AuthFlow.Application.Services.Common;

namespace AuthFlow.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResult> LoginAsync(string email, string password);
    Task<AuthenticationResult> RefreshAsync(string refreshToken);
    Task LogoutAsync(string refreshToken);
}