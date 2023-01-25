using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Common.Result;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation error occurred.");

    Error[] Errors { get; }
}