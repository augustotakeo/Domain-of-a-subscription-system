namespace PaymentContext.Domain.Entities;

public class PaypalPayment(string email, decimal total, decimal totalPaid, string payer, 
    string document) : Payment(total, totalPaid, payer, document) {
    public string Email { get; set; } = email;
    public string TransactionCode { get; set; } = null!;
}