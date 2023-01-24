namespace AuthFlow.Application.Contracts.Authentication;

public record RefreshRequest(
    string RefreshToken
);
