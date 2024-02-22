namespace PaymentContext.Domain.Services;

public interface IEmailService {
    Task Send(string to, string email, string subject, string body);
}