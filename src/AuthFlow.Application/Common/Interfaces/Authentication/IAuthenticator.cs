using AuthFlow.Application.Authentication.Common;
using AuthFlow.Domain.Core.Users;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAuthenticator
{
    Task<AuthenticationResult> Authenticate(User user);
}