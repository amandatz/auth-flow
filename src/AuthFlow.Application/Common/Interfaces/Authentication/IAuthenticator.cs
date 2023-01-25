using AuthFlow.Application.Authentication.Common;
using AuthFlow.Domain.Core.User;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAuthenticator
{
    Task<AuthenticationResult> Authenticate(User user);
}