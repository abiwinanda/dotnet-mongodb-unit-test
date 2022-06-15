# Unit Test with MongoDB in Dotnet

This sample project contains sample code on how to perform unit test in dotnet for classes, modules, or components that contain MongoDB driver.
Instead of mocking every database calls, the approach took in this sample project is by creating a temporary instance of MongoDB and
using that instance to store the unit test (dummy) data. With this approach, the mongodb or database layer does not have to be mocked 
hence more accurate unit test.

## Dependencies

To create a temporary MongoDB instance, this sample project rely on [Mongo2Go NuGet Package](https://github.com/Mongo2Go/Mongo2Go).

## Creating MongoDB Instance for Unit Test

You could create an instance of MongoDB database for your unit test with the following sample code

```c#
public class StudentServiceTest
{
    private readonly MongoDbRunner _runner;
    private readonly StudentService _studentService;
    
    public StudentServiceTest()
    {
        // Creating mongodb runner instance 
        _runner = MongoDbRunner.Start();
        
        // Use the created mongodb runner to store the database data created in the unit tests
        MongoContext mongoContext = new MongoContext(_runner.ConnectionString);
        
        _studentService = new StudentService(mongoContext);
    }
    
    // Test cases
    [Fact]
    public void GetAllStudentsByAge_should_get_students_with_correct_age()
    {
        // code here...
    }
    
    public void Dispose()
    {
        _runner.Dispose();
    }
}
```
