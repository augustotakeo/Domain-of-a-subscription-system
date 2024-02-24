using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public string CardNumer { get; private set; }
    public ECreditCardBrand CardBrand { get; private set; }
    public Name CardHolderName { get; private set; }

    public CreditCardPayment(string cardNumber, ECreditCardBrand cardBrand, Name cardHolderName, decimal total, Name payer, Document document) :
        base(total, payer, document)
    {
        CardNumer = cardNumber;
        CardHolderName = cardHolderName;
        CardBrand = cardBrand;
    
        AddNotifications(new Contract<Notification>()
            .Requires()
            .Matches(CardNumer, "[0-9]{4}", "Number should have 4 digits")
        );
        AddNotifications(CardHolderName);
    }
}