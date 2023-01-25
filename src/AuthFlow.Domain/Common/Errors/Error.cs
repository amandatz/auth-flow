using AuthFlow.Domain.Common.Models;

namespace AuthFlow.Domain.Common.Errors;

public class Error : ValueObject
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    internal static Error None => new(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Message;
        yield return Code;
    }
}