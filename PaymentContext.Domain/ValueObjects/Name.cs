using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject {
    public Name(string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Notification>()
            .IsBetween(FirstName.Length, 3, 100, "Name.FirstName")
            .IsBetween(LastName.Length, 3, 200, "Name.LastName"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}