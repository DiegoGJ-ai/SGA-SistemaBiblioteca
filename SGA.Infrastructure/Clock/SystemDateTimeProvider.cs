using SGA.Application.Interfaces;

namespace SGA.Infrastructure.Clock;
public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
