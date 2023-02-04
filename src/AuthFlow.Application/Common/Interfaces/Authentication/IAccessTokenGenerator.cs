using AuthFlow.Domain.Core.Users;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}