using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks;

public class FakeEmailService : IEmailService
{
    public Task Send(string to, string email, string subject, string body)
    {
        return Task.CompletedTask;
    }
}