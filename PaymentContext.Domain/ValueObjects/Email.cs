using Flunt.Validations;
using Flunt.Notifications;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject {
    public string  Address { get; private set; }
    
    public Email(string address) {
        Address = address;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(address, "Email.Address", "Invalid email address"));
    }

    public override bool Equals(object? obj)
    {
        if(obj is not Email)
            return false;

        var email = (Email)obj;
        return email.Address == Address;
    }

    public override int GetHashCode()
    {
        return Address.GetHashCode();
    }
}