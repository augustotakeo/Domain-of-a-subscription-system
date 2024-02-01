namespace PaymentContext.Domain.Entities;

public class Student {
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<Subscription> Subscriptions { get; set; } = null!;
}