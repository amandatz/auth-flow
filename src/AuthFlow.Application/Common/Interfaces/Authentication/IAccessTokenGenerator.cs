using AuthFlow.Domain.Core.User;

namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}