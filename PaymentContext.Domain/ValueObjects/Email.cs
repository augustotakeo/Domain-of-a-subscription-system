using Flunt.Validations;
using Flunt.Notifications;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject {
    public Email(string address) {
        Address = address;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(address, "Email.Address", "Invalid email address"));
    }

    public string  Address { get; private set; }
}