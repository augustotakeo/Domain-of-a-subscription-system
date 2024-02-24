using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

public class CreateCreditCardSubscriptionCommandHandleTests {

    private static CreateCreditCardSubscriptionCommand ValidCommand() => new() {
        CreditCardHolderFirstName = "CCH",
        CreditCardHolderLastName = "Junior",
        CreditCardNumer = "5196",
        CreditCardBrand = Domain.Enums.ECreditCardBrand.ALELO,
        PaidDate = DateTime.Now,
        PayerDocument = "04096689000150",
        PayerDocumentType = Domain.Enums.EDocumentType.CNPJ,
        PayerFirstName = "PFN",
        PayerLastName = "Junior",
        PaymentTotal = 100,
        StudentDocument = "59565811078",
        StudentEmail = "student@gmail.com",
        StudentFirstName = "SFN",
        StudentLastName = "Junior"
    };

    [Fact]
    public void ShouldReturnSuccessWhenCommandIsValid() {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        handler.Handle(ValidCommand()).Wait();
        Assert.True(handler.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenStudentIsInvalid() {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = ValidCommand();
        command.StudentEmail = "invalid email";
        handler.Handle(command).Wait();
        Assert.False(handler.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenEmailExists() {
        var studentRepository = new FakeStudentRepository();
        var handler = new SubscriptionHandler(studentRepository, new FakeEmailService());
        var command = ValidCommand();
        command.StudentEmail = studentRepository.Emails[0].Address;
        handler.Handle(command).Wait();
        Assert.False(handler.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenDocumentExists() {
        var studentRepository = new FakeStudentRepository();
        var handler = new SubscriptionHandler(studentRepository, new FakeEmailService());
        var command = ValidCommand();
        command.StudentDocument = studentRepository.Documents[0].Number;
        handler.Handle(command).Wait();
        Assert.False(handler.IsValid);
    }
}