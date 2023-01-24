using AuthFlow.Application.Common.Interfaces.Services;

namespace AuthFlow.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}