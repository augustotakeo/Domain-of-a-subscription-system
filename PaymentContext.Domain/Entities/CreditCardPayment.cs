using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment {
    public string CardNumer { get; private set; } 
    public Name CardHolderName { get; private set; }

    public CreditCardPayment(string cardNumber, Name cardHolderName, decimal total, Name payer, Document document) : 
        base(total,  payer, document) {
            CardNumer = cardNumber;
            CardHolderName = cardHolderName;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsCreditCard(CardNumer, "CreditCardPayment.CardNumber", "Invalid credit card number")
        );
        AddNotifications(CardHolderName);
    }
}