using AuthFlow.Domain.Common.Errors;

namespace AuthFlow.Domain.Common.Result;

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value cannot be accessed.");
}