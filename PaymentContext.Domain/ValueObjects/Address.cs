using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject {

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }    
    public string State { get; private set; }
    public string Country { get; private set; }
    
    public Address(string street, string number, string neighborhood, string zipCode, string city, string state, string country)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        ZipCode = zipCode;
        City = city;
        State = state;
        Country = country;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsBetween(street.Length, 3, 200, "Address.Street", "Street should have between 3 and 200 characters")
            .IsBetween(street.Length, 3, 200, "Address.Number", "Number should have between 3 and 200 characters")
            .IsBetween(street.Length, 3, 200, "Address.Neighborhood", "Neighborhood should have between 3 and 200 characters")
            .IsBetween(street.Length, 3, 200, "Address.ZipCode", "ZipCode should have between 3 and 200 characters")
            .IsBetween(street.Length, 3, 200, "Address.City", "City should have between 3 and 200 characters")
            .IsBetween(street.Length, 3, 200, "Address.Country", "Country should have between 3 and 200 characters")
            .Matches(Number, "^[0-9]", "Number")
        );
    }
}