namespace AuthFlow.Application.Contracts.Authentication;

public record LogoutRequest(
    string RefreshToken
);