using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment(string cardNumber, string cardHolderName, 
        string lastTransactionNumber, decimal total, decimal totalPaid, string payer, 
        Document document) : Payment(total, totalPaid, payer, document) {
    public string CardNumer { get; private set; } = cardNumber;
    public string CardHolderName { get; private set; } = cardHolderName;
    public string LastTransactionNumber { get; private set; } = lastTransactionNumber;
}