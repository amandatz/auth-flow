using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Common.Result;

public static class ResultExtensions
{
    public static T Match<T>(this Result result, Func<T> success, Func<List<Error>, T> failure)
    {
        if (result.IsSuccess)
            return success();

        if (result is ValidationResult validationResult)
            return failure(validationResult.Errors);

        return failure(new() { result.Error });
    }
}