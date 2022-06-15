using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SampleMongodbUnitTest.Database;
using SampleMongodbUnitTest.Models;
using SampleMongodbUnitTest.Services;

namespace SampleMongodbUnitTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return _studentService.GetAllStudents();
    }
    
    [HttpGet("{id}")]
    public Student? Get(string id)
    {
        return _studentService.GetStudentById(id);
    }

    [HttpPost]
    public Student Post(CreateStudentRequest request)
    {
        var newStudent = new Student
        {
            Name = request.Name,
            Age = request.Age,
            HomeAddress = request.HomeAddress
        };
        
        _studentService.AddStudent(newStudent);

        return newStudent;
    }
}
