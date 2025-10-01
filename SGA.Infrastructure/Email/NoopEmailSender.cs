using SGA.Application.Interfaces;

namespace SGA.Infrastructure.Email;
public class NoopEmailSender : IEmailSender
{
    public Task SendAsync(string to, string subject, string htmlBody)
    {
        
        Console.WriteLine($"[Email NO-OP] To:{to} Subject:{subject}");
        return Task.CompletedTask;
    }
}
