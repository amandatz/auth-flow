namespace AuthFlow.Application.Common.Interfaces.Authentication;

public interface IRefreshTokenValidator
{
    bool Validate(string refreshToken);
}