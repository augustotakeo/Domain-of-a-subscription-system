namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment {
    public string CardNumer { get; set; } = null!;
    public string CardHolderName { get; set; } = null!;
    public string LastTransactionNumber { get; set; } = null!;
}