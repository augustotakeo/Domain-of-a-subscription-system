using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PaypalPayment(string email, decimal total, decimal totalPaid, string payer, 
    Document document) : Payment(total, totalPaid, payer, document) {
    public string Email { get; set; } = email;
    public string TransactionCode { get; set; } = null!;
}