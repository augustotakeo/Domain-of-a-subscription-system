namespace PaymentContext.Domain.Entities;

public class PaypalPayment : Payment {
    public string Email { get; set; } = null!;
    public string TransactionCode { get; set; } = null!;
}