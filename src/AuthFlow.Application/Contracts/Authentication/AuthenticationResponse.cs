namespace AuthFlow.Application.Contracts.Authentication;

public record AuthenticationResponse(
    Guid UserId,
    string AccessToken,
    string RefreshToken
);