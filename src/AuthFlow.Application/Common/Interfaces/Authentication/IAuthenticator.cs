using AuthFlow.Application.Services.Authentication;
using AuthFlow.Domain.User;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAuthenticator
{
    Task<AuthenticationResult> Authenticate(User user);
}