using AuthFlow.Domain.User;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}