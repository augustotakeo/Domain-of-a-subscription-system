using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment {
    public string CardNumer { get; private set; } 
    public Name CardHolderName { get; private set; }
    public string LastTransactionNumber { get; private set; }

    public CreditCardPayment(string cardNumber, Name cardHolderName, 
        string lastTransactionNumber, decimal total, decimal totalPaid, Name payer, 
        Document document) : base(total, totalPaid, payer, document) {
            CardNumer = cardNumber;
            CardHolderName = cardHolderName;
            LastTransactionNumber = lastTransactionNumber;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsCreditCard(CardNumer, "CreditCardPayment.CardNumber", "Invalid credit card number")
            .Matches(LastTransactionNumber, "^[0-9][a-z][A-Z]-", "CreditCardPayment.LastTransactionNumber", "Inavlid transaction number"));
        AddNotifications(CardHolderName);
    }
}