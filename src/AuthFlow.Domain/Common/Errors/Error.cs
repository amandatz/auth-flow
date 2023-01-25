using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.Common.Errors;

public class Error : ValueObject
{
    protected Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    public ErrorType Type { get; }
    public string Code { get; }
    public string Message { get; }

    public static Error Conflict(string code, string message) => new(ErrorType.Conflict, code, message);

    public static Error Validation(string code, string message) => new(ErrorType.Validation, code, message);

    public static Error NotFound(string code, string message) => new(ErrorType.NotFound, code, message);

    public static Error Unknown(string code, string message) => new(ErrorType.Unknown, code, message);

    internal static Error None => Error.Unknown(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return Code;
        yield return Message;
    }
}