using System.Linq.Expressions;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Queries;

public static class StudentQueries {

    public static Expression<Func<Student, bool>> GetStudentInfoByDocument(string number)
        => x => x.Document.Number == number && x.Document.Type == Enums.EDocumentType.CPF;

    public static Expression<Func<Student, bool>> GetStudentInfoByEmail(Email email)
        => x => x.Email.Equals(email);

}