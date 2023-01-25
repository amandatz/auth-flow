using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Common.Result;

public interface IValidationResult
{
    public static readonly Error ValidationError = Error.Validation(
        "ValidationError",
        "A validation error occurred.");

    List<Error> Errors { get; }
}