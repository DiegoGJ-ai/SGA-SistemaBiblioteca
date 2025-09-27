namespace SGA.Application.Interfaces;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
