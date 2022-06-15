using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SampleMongodbUnitTest.Models;

public class Student
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string HomeAddress { get; set; } = string.Empty;
}

public class CreateStudentRequest
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string HomeAddress { get; set; } = string.Empty;
}