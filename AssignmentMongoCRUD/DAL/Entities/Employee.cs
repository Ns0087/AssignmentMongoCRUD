using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssignmentMongoCRUD.DAL.Entities
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("First Name")]
        public string? FirstName { get; set; }

        [BsonElement("Last Name")]
        public string? LastName { get; set; }

        [BsonElement("Email Address")]
        public string? EmailAddress { get; set; }

        [BsonElement("Department")]
        public string? Department { get; set; }

        [BsonElement("Salary")]
        public string? Salary { get; set; }
    }
}
