using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

public class StudentTests {

    private readonly Email Email;
    private readonly Name Name;
    private readonly Document Document;
    private readonly DateTime? ValidExpireDate;
    private readonly DateTime? InvalidExpireDate;

    public StudentTests() {
        Email = new("teste@gmail.com");
        Name = new("Teste", "Junior");
        Document = new("69391724086", Domain.Enums.EDocumentType.CPF);
        ValidExpireDate = DateTime.Now.AddDays(1);
        InvalidExpireDate = DateTime.Now.AddDays(-1);
    }

    [Fact]
    public void ShouldReturnErrorWhenHasActiveSubscription() {
        var payment = new PaypalPayment(Email, 20, Name, Document);
        var subscription = new Subscription(ValidExpireDate);
        subscription.AddPayment(payment);
        var student = new Student(Name, Document, Email);
        student.AddSubscription(subscription);
        student.AddSubscription(subscription);
        Assert.False(student.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenHasNoActiveSubscription() {
        var payment = new PaypalPayment(Email, 20, Name, Document);
        var subscription = new Subscription(ValidExpireDate);
        subscription.AddPayment(payment);
        var student = new Student(Name, Document, Email);
        student.AddSubscription(subscription);
        Assert.True(subscription.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment() {
        var subscription = new Subscription(ValidExpireDate);
        var student = new Student(Name, Document, Email);
        student.AddSubscription(subscription);
        Assert.False(student.IsValid);
    }
}