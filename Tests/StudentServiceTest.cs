using Mongo2Go;
using Xunit;
using SampleMongodbUnitTest.Database;
using SampleMongodbUnitTest.Services;

namespace SampleMongodbUnitTest.Tests;

public class StudentServiceTest
{
    private readonly StudentService _studentService;
    
    public StudentServiceTest()
    {
        var runner = MongoDbRunner.Start();
        MongoContext mongoContext = new MongoContext(runner.ConnectionString);
        _studentService = new StudentService(mongoContext);
    }
    
    [Fact]
    public void one_plus_one_should_equal_two()
    {
        Assert.Equal(2, 1 + 1);
    }

    [Fact]
    public void should_create_a_new_student()
    {
        var students = _studentService.GetAllStudents();
        Assert.Empty(students.ToList());

        _studentService.AddStudent(new()
        {
            Name = "Name",
            Age = 20,
            HomeAddress = "HomeAddress"
        });
        
        _studentService.AddStudent(new()
        {
            Name = "Name",
            Age = 20,
            HomeAddress = "HomeAddress"
        });
        
        students = _studentService.GetAllStudents();
        Assert.Equal(2, students.ToList().Count);
    }

    [Fact]
    public void GetAllStudentsByAge_should_get_students_with_correct_age()
    {
        _studentService.AddStudent(new()
        {
            Name = "Name",
            Age = 20,
            HomeAddress = "HomeAddress"
        });
        
        _studentService.AddStudent(new()
        {
            Name = "Name",
            Age = 21,
            HomeAddress = "HomeAddress"
        });
        
        _studentService.AddStudent(new()
        {
            Name = "Name",
            Age = 22,
            HomeAddress = "HomeAddress"
        });
        
        _studentService.AddStudent(new()
        {
            Name = "Name",
            Age = 22,
            HomeAddress = "HomeAddress"
        });

        var twenties = _studentService.GetAllStudentsByAge(20);
        var twentyOnes = _studentService.GetAllStudentsByAge(21);
        var twentyTwos = _studentService.GetAllStudentsByAge(22);
        
        Assert.Single(twenties.ToList());
        Assert.Single(twentyOnes.ToList());
        Assert.Equal(2, twentyTwos.ToList().Count);
    }
}
