namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IRefreshTokenGenerator
{
    string Generate();
}