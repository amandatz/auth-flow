using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Core.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            message: "User with this email already exists.");

        public static Error InvalidUser => Error.Validation(
            code: "User.InvalidUser",
            message: "Invalid user.");
    }
}
