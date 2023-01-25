using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Common.Result;

public sealed class ValidationResult : Result, IValidationResult
{
    private ValidationResult(List<Error> errors)
        : base(false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }

    public List<Error> Errors { get; }

    public static ValidationResult WithErrors(List<Error> errors)
        => new(errors);
}