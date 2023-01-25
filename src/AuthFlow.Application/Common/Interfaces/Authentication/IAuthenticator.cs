using AuthFlow.Application.Services.Common;
using AuthFlow.Domain.User;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAuthenticator
{
    Task<AuthenticationResult> Authenticate(User user);
}