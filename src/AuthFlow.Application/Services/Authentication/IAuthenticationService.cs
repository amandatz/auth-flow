namespace AuthFlow.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task RegisterAsync();
    Task LoginAsync();
    Task RefreshAsync();
    Task LogoutAsync();
}