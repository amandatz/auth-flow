using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Common.Result;

public static class ResultExtensions
{
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<List<Error>, T> onFailure)
    {
        if (result.IsSuccess)
            return onSuccess();

        if (result is ValidationResult validationResult)
            return onFailure(validationResult.Errors);

        return onFailure(new() { result.Error });
    }

    public static TOut Match<TIn, TOut>(this Result<TIn> resultTask, Func<TIn, TOut> onSuccess, Func<List<Error>, TOut> onFailure)
    {
        if (resultTask.IsSuccess)
            return onSuccess(resultTask.Value);

        if (resultTask is ValidationResult<TIn> validationResult)
            return onFailure(validationResult.Errors);

        return onFailure(new() { resultTask.Error });
    }
}