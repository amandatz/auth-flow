namespace AuthFlow.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task RegisterAsync(string firstName, string lastName, string email, string password);
    Task<AuthenticationResult> LoginAsync(string email, string password);
    Task<AuthenticationResult> RefreshAsync(string refreshToken);
    Task LogoutAsync(string refreshToken);
}