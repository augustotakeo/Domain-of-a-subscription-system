using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService) :
    Notifiable<Notification>,
    IHandler<CreateCreditCardSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IEmailService _emailService = emailService;

    public async Task<ICommandResult> Handle(CreateCreditCardSubscriptionCommand command)
    {
        var payment = new CreditCardPayment(
            command.CreditCardNumer,
            command.CreditCardBrand,
            new Name(command.CreditCardHolderFirstName, command.CreditCardHolderLastName),
            command.PaymentTotal,
            new Name(command.PayerFirstName, command.PayerLastName),
            new Document(command.PayerDocument, command.PayerDocumentType)
        );
        var subscription = new Subscription(null);
        var student = new Student(
            new Name(command.StudentFirstName, command.StudentLastName),
            new Document(command.StudentDocument, Enums.EDocumentType.CPF),
            new Email(command.StudentEmail)
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(student);

        if(await _studentRepository.EmailExists(student.Email))
            AddNotification("Email", "Email já está em uso.");

        if(await _studentRepository.DocumentExists(student.Document))
            AddNotification("CPF", "CPF já está em uso");

        if (!IsValid)
            return CommandResult.New(false, "Não foi possível realizar assinatura");

        await _studentRepository.CreateStudent(student);

        await _emailService.Send(student.Name.ToString(), student.Email.Address, "Seja bem vindo", "Sua assinatura foi criada com sucesso");

        return CommandResult.New(true, "Assinatura criada com sucesso");
    }

    public async Task<ICommandResult> Handle(CreatePayPalSubscriptionCommand command)
    {
        var payment = new PaypalPayment(
            new Email(command.PayPalEmail),
            command.PaymentTotal,
            new Name(command.PayerFirstName, command.PayerLastName),
            new Document(command.PayerDocument, command.PayerDocumentType)
        );
        var subscription = new Subscription(null);
        var student = new Student(
            new Name(command.StudentFirstName, command.StudentLastName),
            new Document(command.StudentDocument, Enums.EDocumentType.CPF),
            new Email(command.StudentEmail)
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(student);

        if(await _studentRepository.EmailExists(student.Email))
            AddNotification("Email", "Email já está em uso.");

        if(await _studentRepository.DocumentExists(student.Document))
            AddNotification("CPF", "CPF já está em uso");

        if(!IsValid)
            return CommandResult.New(false, "Não foi possível realizar assinatura");

        await _studentRepository.CreateStudent(student);

        await _emailService.Send(student.Name.ToString(), student.Email.Address, "Seja bem vindo", "Sua assinatura foi criada com sucesso");

        return CommandResult.New(true, "Assinatura criada com sucesso");
    }
}