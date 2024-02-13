using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

public class SubscriptionTests {

    private readonly Email Email;
    private readonly Name Name;
    private readonly Document Document;
    private readonly DateTime? ValidExpireDate;
    private readonly DateTime? InvalidExpireDate;

    public SubscriptionTests() {
        Email = new("teste@gmail.com");
        Name = new("Teste", "Junior");
        Document = new("69391724086", Domain.Enums.EDocumentType.CPF);
        ValidExpireDate = DateTime.Now.AddDays(1);
        InvalidExpireDate = DateTime.Now.AddDays(-1);
    }

    [Fact]
    public void ShouldReturnErrorWhenExpireDateIsInvalid() {
        var subscription = new Subscription(InvalidExpireDate);
        Assert.False(subscription.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenExpireDateIsValid() {
        var subscription = new Subscription(ValidExpireDate);
        Assert.True(subscription.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenExpireDateIsNull() {
        var subscription = new Subscription(null);
        Assert.True(subscription.IsValid);
    }

    [Fact]
    public async Task ShouldBeInactiveWhenIsExpired() {
        var subscription = new Subscription(DateTime.Now.AddMilliseconds(1000));
        await Task.Delay(1500);
        Assert.False(subscription.Active());
    }

    [Fact]
    public void ShouldBeActiveWhenIsNotExpired() {
        var subscription = new Subscription(ValidExpireDate);
        Assert.True(subscription.Active());
    }

    [Fact]
    public void ShouldReturnErrorWhenAddInvalidPayment() {
        var payment = new PaypalPayment(Email, -20, Name, Document);
        var subscription = new Subscription(ValidExpireDate);
        subscription.AddPayment(payment);
        Assert.False(subscription.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenAddNullPayment() {
        var subscription = new Subscription(ValidExpireDate);
        subscription.AddPayment(null);
        Assert.False(subscription.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhenAddValidPayment() {
        var payment = new PaypalPayment(Email, 20, Name, Document);
        var subscription = new Subscription(ValidExpireDate);
        subscription.AddPayment(payment);
        Assert.True(subscription.IsValid);
    }
}