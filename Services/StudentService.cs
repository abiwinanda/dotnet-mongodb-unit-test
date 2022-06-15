using MongoDB.Driver;
using SampleMongodbUnitTest.Database;
using SampleMongodbUnitTest.Models;

namespace SampleMongodbUnitTest.Services;

public class StudentService
{
    private readonly IMongoCollection<Student> _studentCollection;

    public StudentService(MongoContext mongoContext)
    {
        _studentCollection = mongoContext.GetCollection<Student>("students");
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _studentCollection.AsQueryable().ToList();
    }
    
    public IEnumerable<Student> GetAllStudentsByAge(int age)
    {
        return _studentCollection.AsQueryable()
            .Where(s => s.Age == age)
            .ToList();
    }
    
    public Student? GetStudentById(string id)
    {
        return _studentCollection.AsQueryable().SingleOrDefault(s => s.Id == id);
    }

    public void AddStudent(Student newStudent)
    {
        _studentCollection.InsertOne(newStudent);
    }
}
