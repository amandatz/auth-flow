using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Core.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCred",
            message: "Invalid credentials.");

        public static Error InvalidRefreshToken => Error.Validation(
            code: "Auth.InvalidRefreshToken",
            message: "Invalid refresh token.");
    }
}
