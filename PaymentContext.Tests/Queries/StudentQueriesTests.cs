using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

public class StudentQueriesTests {

    private IList<Student> _students;
 
    public StudentQueriesTests() {
        _students = [
            new(new Name("Arnaldo", "Junior"), 
                new Document("02726118089", Domain.Enums.EDocumentType.CPF), 
                new Email("arnaldo@gmail.com")),
            new(new Name("Bernaldo", "Junior"), 
                new Document("81620536030", Domain.Enums.EDocumentType.CPF), 
                new Email("bernaldo@gmail.com")),
            new(new Name("Cernaldo", "Junior"), 
                new Document("31975040031", Domain.Enums.EDocumentType.CPF), 
                new Email("cernaldo@gmail.com")),
            new(new Name("Dernaldo", "Junior"), 
                new Document("58012209098", Domain.Enums.EDocumentType.CPF), 
                new Email("dernaldo@gmail.com")),
            new(new Name("Ernaldo", "Junior"), 
                new Document("94384742002", Domain.Enums.EDocumentType.CPF), 
                new Email("ernaldo@gmail.com")),
        ];
    }

    [Fact]
    public void ShouldReturnNullWhenDocumentNotExists() {
        var query = StudentQueries.GetStudentInfoByDocument("123");
        var student = _students.AsQueryable().Where(query).FirstOrDefault();
        Assert.Null(student);
    }

    [Fact]
    public void ShouldReturnStudentWhenDocumentExists() {
        var query = StudentQueries.GetStudentInfoByDocument("31975040031");
        var student = _students.AsQueryable().Where(query).FirstOrDefault();
        Assert.True(student?.Document.Number.Equals("31975040031"));
    }

    [Fact]
    public void ShouldReturnNullWhenEmailNotExists() {
        var email = new Email("zsd");
        var query = StudentQueries.GetStudentInfoByEmail(email);
        var student = _students.AsQueryable().Where(query).FirstOrDefault();
        Assert.Null(student);
    }

    [Fact]
    public void ShouldReturnStudentWhenEmailExists() {
        var email = new Email("bernaldo@gmail.com");
        var query = StudentQueries.GetStudentInfoByEmail(email);
        var student = _students.AsQueryable().Where(query).FirstOrDefault();
        Assert.True(student?.Email.Equals(email));
    }

}